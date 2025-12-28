using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UrlShortner.Application.Dtos.Url;
using UrlShortner.Interfaces;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UrlService(UrlShortnerContext context, IMapper mapper) : IUrlService
    {
        public async Task<UrlDto> CreateShortUrlAsync(CreateShortUrlRequest request)
        {
            if (!context.Users.Any(u => u.Id == request.UserId))
                throw new Exception("User not found");
            
            var url = new Url
            {
                OriginalUrl = request.OriginalUrl,
                ShortnedUrl = await GenerateRandomShortUrl(request.BaseUrl),
                UserId = request.UserId
            };
            
            context.Urls.Add(url);
            await context.SaveChangesAsync();

            return mapper.Map<UrlDto>(url);
        }
        public async Task<string> GenerateRandomShortUrl(string baseUrl)
        {
            string url = Guid.NewGuid().ToString()[..5];
            if (await context.Urls.AnyAsync(u => u.ShortnedUrl == url))
                return await GenerateRandomShortUrl(baseUrl);
            return baseUrl + "/" + url;
        }

        public Task<string?> GetOriginalUrlByShortnedVersion(string shortnedUrl)
        {
            return context.Urls
                .Where(u => u.ShortnedUrl.EndsWith(shortnedUrl))
                .Select(u => u.OriginalUrl)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UrlDto>> GetUrls(int take, int startIndex)
        {
            return await context.Urls
                .OrderBy(u => u.Id)
                .Skip(startIndex)
                .Take(take)
                .ProjectTo<UrlDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
