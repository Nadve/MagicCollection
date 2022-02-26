namespace DownloadCards.Models.Prices.Cards
{
    internal class CardPrice
    {
        public int PriceId { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public double Price { get; set; }
    }
}
