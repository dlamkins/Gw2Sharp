using System;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp
{
    /// <summary>
    /// A custom JSON converter that handles PvP season leaderboard settings tier range conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{PvpSeasonLeaderboardLadderSettingsTierRange}" />
    public class PvpSeasonLeaderboardSettingsTierRangeConverter : JsonConverter<PvpSeasonLeaderboardSettingsTierRange>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override PvpSeasonLeaderboardSettingsTierRange ReadJson(JsonReader reader, Type objectType, PvpSeasonLeaderboardSettingsTierRange existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!(serializer.Deserialize<JToken>(reader) is JArray jArray))
                throw new JsonSerializationException($"Expected {nameof(jArray)} to be an array");

            return new PvpSeasonLeaderboardSettingsTierRange(jArray[0].ToObject<double>(serializer), jArray[1].ToObject<double>(serializer));
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, PvpSeasonLeaderboardSettingsTierRange value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
