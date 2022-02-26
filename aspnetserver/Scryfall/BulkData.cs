using System.Text.Json.Serialization;

namespace aspnetserver.Scryfall
{
    internal class BulkData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("download_uri")]
        public string Uri { get; set; }
    }
}
