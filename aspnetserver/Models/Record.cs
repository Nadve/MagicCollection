using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models
{
    internal sealed class Record
    {
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
