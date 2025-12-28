using UrlShortner.Application.Dtos.Url;

namespace UrlShortner.Interfaces
{
    public interface IUrlService
    {
        public Task<UrlDto> CreateShortUrlAsync(CreateShortUrlRequest request);
        public Task<string> GenerateRandomShortUrl(string baseUrl);
        Task<List<UrlDto>> GetUrls(int take, int startIndex);
        Task<string?> GetOriginalUrlByShortnedVersion(string shortnedUrl);
    }
}
