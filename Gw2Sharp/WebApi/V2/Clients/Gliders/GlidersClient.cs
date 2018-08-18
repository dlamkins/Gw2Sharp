using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 gliders endpoint.
    /// </summary>
    [EndpointPath("gliders")]
    public class GlidersClient : BaseEndpointBulkAllClient<Glider, int>, IGlidersClient
    {
        /// <summary>
        /// Creates a new <see cref="GlidersClient"/> that is used for the API v2 gliders endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public GlidersClient(IConnection connection) : base(connection) { }
    }
}
