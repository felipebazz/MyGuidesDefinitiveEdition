using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Steam.Api.Responses
{
    [ExcludeFromCodeCoverage]
    public class SchemaForGameResponse
    {
        [JsonProperty("game")]
        public Game Game { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Game
    {
        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        public string AppId { get; set; }

        [JsonProperty("availableGameStats")]
        public AvailableGameStats AvailableGameStats { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AvailableGameStats
    {
        [JsonProperty("achievements")]
        public IEnumerable<Achievement> Achievements { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Achievement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("defaultvalue")]
        public int Defaultvalue { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("hidden")]
        public int Hidden { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icongray")]
        public string Icongray { get; set; }
    }
}
