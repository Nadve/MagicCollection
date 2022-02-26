using System.Text.Json.Serialization;

namespace aspnetserver.Scryfall
{
    internal class CardFace
    {
        [JsonPropertyName("image_uris")]
        public ImageUris ImageUri { get; set; }
    }
}
