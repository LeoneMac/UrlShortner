using Microsoft.AspNetCore.Mvc;
using UrlShortner.Application.Dtos.User;
using UrlShortner.Interfaces;

namespace UrlShortner.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService) : ControllerBase
{
    public async Task<IActionResult> GetUsers(int take = 10, int startIndex = 0)
    {
        return Ok(await userService.GetUsers(take, startIndex));
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var creationResult = await userService.CreateAsync(request);
        if (creationResult.errors != null)
            return BadRequest(creationResult);
        return CreatedAtAction(nameof(Create), new { id = creationResult.user!.Id }, creationResult.user);
    }
}
