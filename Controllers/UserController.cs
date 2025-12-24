using Microsoft.AspNetCore.Mvc;
using UrlShortner.DTOs;
using UrlShortner.Services;

namespace UrlShortner.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var user = await _service.CreateAsync(request);
        return Created("user", user);
    }
}
