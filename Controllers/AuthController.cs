using interndotnet.Models;
using interndotnet.Services;
using interndotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interndotnet.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IUserService _userService;

    public AuthController(JwtService jwtService,IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin login)
    {
        Console.WriteLine("Hello successful");
        var user = await _userService.AuthenticateAsync(login.Username, login.Password);
        
        if (user == null) return Unauthorized();
        var token = _jwtService.GenerateToken(login.Username);
        return Ok(new { token });
        
    }
}