using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models.Prices.Records
{
    internal abstract class RecordPrice
    {
        public int Id { get; set; }

        [Required]
        public double Price { get; set; }

        public Card Record { get; set; }
        public int RecordId { get; set; }
    }
}
