using System.Text.Json.Serialization;

namespace aspnetserver.Scryfall
{
    internal class ImageUris
    {
        [JsonPropertyName("large")]
        public string Large { get; set; }

        [JsonPropertyName("normal")]
        public string Normal { get; set; }

        [JsonPropertyName("small")]
        public string Small { get; set; }
    }
}
