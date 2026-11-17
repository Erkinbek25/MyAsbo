using Microsoft.AspNetCore.Mvc;
using MyAsbo.Service.DTOs.Auth;
using MyAsbo.Service.Interfaces;

namespace MyAsbo.Api.Controllers;

[Route("api/Auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController( IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        return Ok(new {token});
    }



}
