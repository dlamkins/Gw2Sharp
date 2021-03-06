using System;
using System.Collections.Generic;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;
using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region map.
    /// </summary>
    public class ContinentFloorRegionMap : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The map id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The map name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The map minimum level.
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// The map maximum level.
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        /// The default floor for this map.
        /// </summary>
        public int DefaultFloor { get; set; }

        /// <summary>
        /// The map label coordinates.
        /// </summary>
        public Coordinates2 LabelCoord { get; set; }

        /// <summary>
        /// The map rectangle.
        /// </summary>
        [JsonConverter(typeof(BottomUpRectangleConverter))]
        public Rectangle MapRect { get; set; }

        /// <summary>
        /// The map continent rectangle.
        /// </summary>
        [JsonConverter(typeof(TopDownRectangleConverter))]
        public Rectangle ContinentRect { get; set; }

        /// <summary>
        /// The map points of interest.
        /// </summary>
        public IReadOnlyDictionary<int, ContinentFloorRegionMapPoi> PointsOfInterest { get; set; } = new Dictionary<int, ContinentFloorRegionMapPoi>();

        /// <summary>
        /// The map tasks.
        /// </summary>
        public IReadOnlyDictionary<int, ContinentFloorRegionMapTask> Tasks { get; set; } = new Dictionary<int, ContinentFloorRegionMapTask>();

        /// <summary>
        /// The map skill challenges (a.k.a. hero points).
        /// </summary>
        public IReadOnlyList<ContinentFloorRegionMapSkillChallenge> SkillChallenges { get; set; } = Array.Empty<ContinentFloorRegionMapSkillChallenge>();

        /// <summary>
        /// The map sectors.
        /// </summary>
        public IReadOnlyDictionary<int, ContinentFloorRegionMapSector> Sectors { get; set; } = new Dictionary<int, ContinentFloorRegionMapSector>();

        // Adventures are listed as an array on the API, but are always empty...
        ///// <summary>
        ///// The map adventures.
        ///// </summary>
        //public IReadOnlyList<ContinentFloorRegionMapAdventure> Adventures { get; set; } = Array.Empty<ContinentFloorRegionMapAdventure>();

        /// <summary>
        /// The map mastery points.
        /// </summary>
        public IReadOnlyList<ContinentFloorRegionMapMasteryPoint> MasteryPoints { get; set; } = Array.Empty<ContinentFloorRegionMapMasteryPoint>();
    }
}
