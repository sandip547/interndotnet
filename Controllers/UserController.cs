using interndotnet.Models;
using interndotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interndotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdUser = await _userService.CreateAsync(user);

        return Ok(new { message = "User created successfully" });
    }
}