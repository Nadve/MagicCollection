namespace aspnetserver.Models.Finishes
{
    internal class CardImage
    {
        public int ImageId { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public string UriLarge { get; set; }
        public string UriNormal { get; set; }
        public string UriSmall { get; set; }
    }
}
