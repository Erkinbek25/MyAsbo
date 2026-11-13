using Microsoft.AspNetCore.Mvc;
using MyAsbo.Service.DTOs.Auth;
using MyAsbo.Service.Interfaces;
using MyAsbo.Service.Services;

namespace MyAsbo.Api.Controllers;

[Route("api/Auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController( AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        return Ok(result);
    }



}
