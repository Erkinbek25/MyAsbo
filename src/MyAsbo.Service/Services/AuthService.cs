using MyAsbo.Data.IRepositories;
using MyAsbo.Domain.Entities;
using MyAsbo.Service.DTOs.Auth;
using MyAsbo.Service.DTOs.Users;
using MyAsbo.Service.Interfaces;

namespace MyAsbo.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Organization> _organizationRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IRepository<User> userRepository,
        IRepository<Organization> organizationRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _tokenService = tokenService;
    }
    public async Task<string> LoginAsync(LoginDto dto)
    {
       var loginExists = await _userRepository.AnyAsync(u => u.Login == dto.Login);
        if(loginExists)
        {
            throw new Exception("Bu login band");
        }

       
    }

    public async Task<UserResultDto> RegisterAsync(RegisterDto dto)
    {
        throw new NotImplementedException();
    }
}
