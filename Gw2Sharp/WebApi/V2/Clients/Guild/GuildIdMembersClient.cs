using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id members endpoint.
    /// </summary>
    [EndpointPath("guild/:id/members")]
    [EndpointPathSegment("id", 0)]
    public class GuildIdMembersClient : BaseEndpointBlobClient<IApiV2ObjectList<GuildMember>>, IGuildIdMembersClient
    {
        private readonly Guid guildId;

        /// <summary>
        /// Creates a new <see cref="GuildIdMembersClient"/> that is used for the API v2 guild id members endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public GuildIdMembersClient(IConnection connection, Guid guildId) :
            base(connection)
        {
            this.guildId = guildId;
        }

        /// <inheritdoc />
        public virtual Guid GuildId => this.guildId;
    }
}