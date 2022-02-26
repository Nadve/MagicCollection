using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DownloadCards
{
    internal class CardJson
    {
        [JsonPropertyName("image_status")]
        public string ImageStatus { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("set_name")]
        public string Set { get; set; }

        [JsonPropertyName("collector_number")]
        public string CollectorNumber { get; set; }

        [JsonPropertyName("mana_cost")]
        public string ManaCost { get; set; }

        [JsonPropertyName("image_uris")]
        public ImageUris ImageUri { get; set; }

        [JsonPropertyName("prices")]
        public Prices Price { get; set; }

        [JsonPropertyName("finishes")]
        public IList<string> Finishes { get; set; }

        [JsonPropertyName("card_faces")]
        public IList<CardFace> CardFaces { get; set; }
    }
}
