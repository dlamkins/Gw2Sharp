using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW endpoint.
    /// </summary>
    [EndpointPath("wvw")]
    public class WvwClient : Gw2WebApiBaseClient, IWvwClient
    {
        private readonly IWvwRanksClient ranks;

        /// <summary>
        /// Creates a new <see cref="WvwClient"/> that is used for the API v2 WvW endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal WvwClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.ranks = new WvwRanksClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IWvwRanksClient Ranks => this.ranks;

    }
}
