namespace aspnetserver.Models
{
    internal class Possession
    {
        public int PossessionId { get; set; }

        public Card Card { get; set; }
        public int CardId { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }

        public int Count { get; set; } = 1;

        public string Finish { get; set; } = "non-foil";
    }
}
