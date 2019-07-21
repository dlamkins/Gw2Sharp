using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange gems endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange/gems")]
    public class CommerceExchangeGemsClient : BaseEndpointBlobClient<CommerceExchangeGems>, ICommerceExchangeGemsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceExchangeGemsClient"/> that is used for the API v2 commerce exchange gems endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal CommerceExchangeGemsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public ICommerceExchangeGemsQuantityClient Quantity(int quantity) => new CommerceExchangeGemsQuantityClient(this.Connection, this.Gw2Client!, quantity);
    }
}
