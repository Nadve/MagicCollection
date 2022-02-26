using System.Text.Json.Serialization;

namespace DownloadCards
{
    internal class BulkData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("download_uri")]
        public string Uri { get; set; }
    }
}
