using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace interndotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController
{
    [HttpGet("test")]
    [Authorize]
    public String test()
    {
        return "Hello World";
    }
    
}