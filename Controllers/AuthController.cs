using interndotnet.Models;
using interndotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace interndotnet.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(UserLogin login)
    {
        if (login.Username == "admin" && login.Password == "password")
        {
            var token = _jwtService.GenerateToken(login.Username);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}