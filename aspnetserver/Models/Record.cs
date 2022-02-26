namespace aspnetserver.Models
{
    internal sealed class Record
    {
        public int RecordId { get; set; }

        public int Start { get; set; }
        public int End { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
