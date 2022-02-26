namespace aspnetserver.Models
{
    internal class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        
        public string Password { get; set; }

        public virtual ICollection<Possession> Cards { get; set; }
    }
}
