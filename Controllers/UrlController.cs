using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortner.Application.Dtos.Url;
using UrlShortner.Interfaces;

namespace UrlShortner.Controllers
{
    [ApiController]
    [Route("urls")]
    public class UrlController(IUrlService urlService) : ControllerBase
    {
        public async Task<IActionResult> GetUrls(int take = 10, int startIndex = 0)
        {
            return Ok(await urlService.GetUrls(take, startIndex));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateShortUrlRequest request)
        {
            request.BaseUrl = HttpContext.Request.Host.ToString();
            var urlResponseDto = await urlService.CreateShortUrlAsync(request);
            return Ok(urlResponseDto);
        }
    }
}
