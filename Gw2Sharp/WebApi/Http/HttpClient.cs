using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using SysHttpClient = System.Net.Http.HttpClient;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A basic web client that uses .NET's <see cref="System.Net.Http.HttpClient" />.
    /// </summary>
    public class HttpClient : IHttpClient
    {
        private static readonly SysHttpClient sysHttpClient = new SysHttpClient();
        private readonly Func<SysHttpClient> getSysHttpClient = () => sysHttpClient;
        private readonly bool shouldDisposeHttpClient = false;

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> with a built-in <see cref="SysHttpClient"/> instance.
        /// Not recommended if you are running Gw2Sharp for a longer period of time, because of possible DNS changes.
        /// Use <see cref="HttpClient(Func{SysHttpClient})"/> instead that refreshes the HttpClient once in a while (e.g. by using Microsoft.Extensions.Http).
        /// </summary>
        public HttpClient() { }

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> with a provided <see cref="SysHttpClient"/> instance.
        /// Not recommended if you are running Gw2Sharp for a longer period of time, because of possible DNS changes.
        /// Use <see cref="HttpClient(Func{SysHttpClient})"/> instead that refreshes the HttpClient once in a while (e.g. by using Microsoft.Extensions.Http).
        /// </summary>
        public HttpClient(SysHttpClient httpClient) : this(() => httpClient) { }

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> with a provided function that returns a <see cref="SysHttpClient"/> instance.
        /// After every request, the <see cref="SysHttpClient"/> is automatically disposed.
        /// Be sure to prevent over-disposing by using e.g. Microsoft.Extensions.Http.
        /// </summary>
        public HttpClient(Func<SysHttpClient> getHttpClientFunc)
        {
            this.getSysHttpClient = getHttpClientFunc;
            this.shouldDisposeHttpClient = true;
        }

        /// <inheritdoc />
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <inheritdoc />
        public async Task<IHttpResponse> RequestAsync(IHttpRequest request, CancellationToken cancellationToken = default)
        {
            using var responseStream = await this.RequestStreamAsync(request, cancellationToken).ConfigureAwait(false);
            using var streamReader = new StreamReader(responseStream.ContentStream);
            string responseText = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            return new HttpResponse(responseText, responseStream.StatusCode, responseStream.RequestHeaders, responseStream.ResponseHeaders);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseStream> RequestStreamAsync(IHttpRequest request, CancellationToken cancellationToken = default)
        {
            using var cancellationTimeout = new CancellationTokenSource(this.Timeout);
            using var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, cancellationTimeout.Token);
            using var message = new HttpRequestMessage(HttpMethod.Get, request.Url);
            message.Headers.AddRange(request.RequestHeaders);

            Task<HttpResponseMessage>? task = null;
            SysHttpClient? httpClient = null;
            HttpResponseMessage responseMessage;
            HttpResponseStream response;
            try
            {
                httpClient = this.getSysHttpClient();
                if (httpClient == null)
                    throw new InvalidOperationException("HttpClient is null");

                task = httpClient.SendAsync(message, linkedCancellation.Token);
                responseMessage = await task.ConfigureAwait(false);

                await responseMessage.Content.LoadIntoBufferAsync().ConfigureAwait(false);
                var stream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
                var requestHeaders = request.RequestHeaders.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                var responseHeaders = responseMessage.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First());
                responseHeaders.AddRange(responseMessage.Content.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First()));

                response = new HttpResponseStream(stream, responseMessage.StatusCode, requestHeaders, responseHeaders);
            }
            catch (Exception ex)
            {
                if (task == null)
                    throw new RequestException(request, $"Failed to create task", ex);
                else if (task.IsCanceled)
                    throw new RequestCanceledException(request);
                throw new RequestException(request, $"Request error: {task?.Exception?.Message}", ex);
            }
            finally
            {
                if (this.shouldDisposeHttpClient)
                    httpClient?.Dispose();
            }

            if (!responseMessage.IsSuccessStatusCode)
            {
                try
                {
                    using var streamReader = new StreamReader(response.ContentStream);
                    string responseText = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    var httpResponseString = new HttpResponse<string>(responseText, response.StatusCode, response.RequestHeaders, response.ResponseHeaders);
                    throw new UnexpectedStatusException(request, httpResponseString);
                }
                finally
                {
                    response.Dispose();
                }
            }

            return response;
        }
    }
}
