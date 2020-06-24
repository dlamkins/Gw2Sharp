namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW rank.
    /// </summary>
    public class WvwRank : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The WvW rank id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title given for the WvW rank.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The minimum required WvW level for this rank.
        /// </summary>
        public int MinRank { get; set; }
    }
}
