using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 legends endpoint.
    /// </summary>
    [EndpointPath("legends")]
    [EndpointSchemaVersion("2019-12-19T00:00:00.000Z")]
    public class LegendsClient : BaseEndpointBulkAllClient<Legend, string>, ILegendsClient
    {
        /// <summary>
        /// Creates a new <see cref="LegendsClient"/> that is used for the API v2 legends endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal LegendsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
