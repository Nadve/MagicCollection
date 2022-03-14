namespace aspnetserver.Models.Finishes
{
    internal abstract class CardFinish
    {
        public int Id { get; set; }

        public Card Card { get; set; }
        public int CardId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is CardFinish f)
                return CardId == f.CardId;

            return false;
        }

        public override int GetHashCode()
        {
            return CardId + Id;
        }
    }
}
