using UrlShortner.Application.Dtos.Url;

namespace UrlShortner.Application.Dtos.User
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<UrlDto> Urls { get; set; } = [];
        public DateTime? CancelledAt { get; set; }
    }
}
