namespace DownloadCards.Models.Prices.Records
{
    internal class RecordPrice
    {
        public int PriceId { get; set; }
        public Card Record { get; set; }
        public int RecordId { get; set; }
        public double Price { get; set; }
    }
}
