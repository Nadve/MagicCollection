using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models.Images
{
    internal abstract class CardImage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string UriLarge { get; set; }

        [Required]
        [MaxLength(100)]
        public string UriNormal { get; set; }

        [Required]
        [MaxLength(100)]
        public string UriSmall { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is CardImage i)
                return CardId == i.CardId;

            return false;
        }

        public override int GetHashCode()
        {
            return Id + CardId;
        }
    }
}
