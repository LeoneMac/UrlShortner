using UrlShortner.Application.Dtos.User;

namespace UrlShortner.Application.Dtos.Url
{
    public class UrlDto
    {
        public Guid Id { get; set; }
        public string? ShortnedUrl { get; set; }
        public string? OriginalUrl { get; set; }
        public Guid UserId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
