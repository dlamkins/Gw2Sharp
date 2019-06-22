using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild upgrades endpoint.
    /// </summary>
    [EndpointPath("guild/upgrades")]
    public class GuildUpgradesClient : BaseEndpointBulkAllClient<GuildUpgrade, int>, IGuildUpgradesClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildUpgradesClient"/> that is used for the API v2 guild upgrades endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public GuildUpgradesClient(IConnection connection) :
            base(connection)
        { }
    }
}