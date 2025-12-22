using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UrlShortner.Models
{
    public class Url
    {
        [Key]
        public Guid Id { get; set; } = Guid.CreateVersion7();
        [NotNull]
        public required string OriginalUrl { get; set; }
        [NotNull]
        public required string ShortnedUrl { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; } = DateTime.Now.AddHours(24);
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CancelledAt { get; set; } 
    }
}
