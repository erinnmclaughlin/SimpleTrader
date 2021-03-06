namespace SimpleTrader.Domain.Models
{
    public class User : DomainObject
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    }
}
