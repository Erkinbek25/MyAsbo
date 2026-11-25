using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyAsbo.Api.Controllers;

[Route("api/Users")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{

    [HttpGet("me")]
    public IActionResult GetMe()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var login = User.FindFirstValue(ClaimTypes.Name);
        var role = User.FindFirstValue(ClaimTypes.Role);

        return Ok(new { id, login, role });
    }

    [HttpGet("admin-test")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminTest()
    {
        return Ok(new { message = "siz Adminsiz, xush kelibsiz!" });
    }
}

