using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models
{
    internal class Card
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Set { get; set; }

        [Required]
        [MaxLength(50)]
        public string CollectorNumber { get; set; }

        public List<Record> Records { get; set; }
    }
}
