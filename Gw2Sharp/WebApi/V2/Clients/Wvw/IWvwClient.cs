namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API WvW endpoint.
    /// </summary>
    public interface IWvwClient
    {
        /// <summary>
        /// Gets the WvW ranks.
        /// </summary>
        IWvwRanksClient Ranks { get; }
    }
}
