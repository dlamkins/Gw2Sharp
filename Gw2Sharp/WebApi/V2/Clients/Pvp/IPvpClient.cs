namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP endpoint.
    /// </summary>
    public interface IPvpClient : IClient
    {
        /// <summary>
        /// Gets the PvP amulets.
        /// </summary>
        IPvpAmuletsClient Amulets { get; }

        /// <summary>
        /// Gets the PvP games.
        /// Requires scopes: account, pvp.
        /// </summary>
        IPvpGamesClient Games { get; }

        /// <summary>
        /// Gets the PvP heroes.
        /// </summary>
        IPvpHeroesClient Heroes { get; }

        /// <summary>
        /// Gets the PvP ranks.
        /// </summary>
        IPvpRanksClient Ranks { get; }

        /// <summary>
        /// Gets the PvP seasons.
        /// </summary>
        IPvpSeasonsClient Seasons { get; }

        /// <summary>
        /// Gets the PvP stats.
        /// Requires scopes: account, pvp.
        /// </summary>
        IPvpStatsClient Stats { get; }

        /// <summary>
        /// Gets the PvP standings.
        /// Requires scopes: account, pvp.
        /// </summary>
        IPvpStandingsClient Standings { get; }
    }
}
