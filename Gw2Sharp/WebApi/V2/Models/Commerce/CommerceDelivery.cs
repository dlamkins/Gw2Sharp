using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a commerce delivery.
    /// </summary>
    public class CommerceDelivery : ApiV2BaseObject
    {
        /// <summary>
        /// The amount of coin.
        /// </summary>
        public int Coins { get; set; }

        /// <summary>
        /// The items.
        /// </summary>
        public IReadOnlyList<CommerceDeliveryItem> Items { get; set; } = Array.Empty<CommerceDeliveryItem>();
    }
}
