using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommerceExchangeCoinsClientTests : BaseCommerceExchangeClientTests
    {
        public CommerceExchangeCoinsClientTests()
        {
            var connection = new Connection(string.Empty, Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Commerce.Exchange.Coins.Quantity(100000);
            this.Client = this.client;
        }

        private readonly ICommerceExchangeCoinsQuantityClient client;

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceExchangeCoins.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);
    }
}