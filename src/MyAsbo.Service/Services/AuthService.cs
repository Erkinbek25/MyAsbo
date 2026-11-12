using MyAsbo.Data.IRepositories;
using MyAsbo.Domain.Entities;
using MyAsbo.Service.DTOs.Auth;
using MyAsbo.Service.DTOs.Users;
using MyAsbo.Service.Interfaces;

namespace MyAsbo.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Organization> _organizatonRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IRepository<User> userRepository,
        IRepository<Organization> organizatonRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _organizatonRepository = organizatonRepository;
        _tokenService = tokenService;
    }
    public Task<string> LoginAsync(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> RegisterAsync(RegisterDto dto)
    {
        throw new NotImplementedException();
    }
}
