using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<Url> Urls { get; set; } = new HashSet<Url>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CancelledAt { get; set; }
    }
}
