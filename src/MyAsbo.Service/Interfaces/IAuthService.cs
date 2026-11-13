using MyAsbo.Service.DTOs.Auth;
using MyAsbo.Service.DTOs.Users;

namespace MyAsbo.Service.Interfaces;

public interface IAuthService
{
    Task<UserResultDto> RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}
