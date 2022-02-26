using System.Text.Json.Serialization;

namespace aspnetserver.Scryfall
{
    internal class BulkFiles
    {
        [JsonPropertyName("data")]
        public IList<BulkData> Data { get; set; }

        public string? GetDownloadUrl()
        {
            foreach (var data in Data)
            {
                if (data.Type.Equals("all_cards"))
                    return data.Uri;
            }
            return null;
        }
    }
}
