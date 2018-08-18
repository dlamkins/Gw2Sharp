
using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id ranks endpoint.
    /// </summary>
    public interface IGuildIdRanksClient :
        IAuthenticatedClient<IReadOnlyList<GuildRank>>,
        IBlobClient<IReadOnlyList<GuildRank>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
