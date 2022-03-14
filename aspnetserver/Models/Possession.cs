using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models
{
    internal class Possession
    {
        public int Id { get; set; }

        public Card Card { get; set; }
        public int CardId { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }

        [Required]
        public int Count { get; set; } = 1;

        [Required]
        [MaxLength(8)]
        public string Finish { get; set; } = "non-foil";
    }
}
