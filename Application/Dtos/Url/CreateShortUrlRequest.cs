namespace UrlShortner.Application.Dtos.Url
{
    public class CreateShortUrlRequest()
    {
        public required Guid UserId { get; set; }
        public required string OriginalUrl { get; set; }
        public string BaseUrl { get; set; } = "";
    }
}