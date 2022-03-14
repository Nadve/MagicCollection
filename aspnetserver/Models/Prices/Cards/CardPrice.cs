using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models.Prices.Cards
{
    internal abstract class CardPrice
    {
        public int Id { get; set; }
        
        [Required]
        public double Price { get; set; }

        public Card Card { get; set; }
        public int CardId { get; set; }
    }
}
