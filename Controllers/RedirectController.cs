using Microsoft.AspNetCore.Mvc;
using UrlShortner.Interfaces;

namespace UrlShortner.Controllers
{
    [ApiController]
    [Route("")]
    public class RedirectController(IUrlService urlService) : ControllerBase
    {
        [HttpGet("{shortnedUrl}")]
        public async Task<IActionResult> RedirectTo(string shortnedUrl)
        {
            string? originalUrl = await urlService.GetOriginalUrlByShortnedVersion(shortnedUrl);

            if (originalUrl is null)
            {
                return NotFound($"Sorry, but the shortned url '{shortnedUrl}' doesn't exists.");
            }

            return Redirect(originalUrl);
        }
    }
}
