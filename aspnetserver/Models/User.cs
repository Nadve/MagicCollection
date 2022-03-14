using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Models
{
    internal class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public List<Possession> Possessions { get; set; }
    }
}
