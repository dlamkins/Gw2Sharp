namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild storage item.
    /// </summary>
    public class GuildStorageItem
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The amount of items.
        /// </summary>
        public int Count { get; set; }
    }
}
