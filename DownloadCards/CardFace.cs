using System.Text.Json.Serialization;

namespace DownloadCards
{
    internal class CardFace
    {
        [JsonPropertyName("image_uris")]
        public ImageUris ImageUri { get; set; }
    }
}
