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

        throw new NotImplementedException();

    }

    public async Task<UserResultDto> RegisterAsync(RegisterDto dto)
    {
        var loginExists = await _userRepository.AnyAsync(u => u.Login == dto.Login);
        if (loginExists)
        {
            throw new Exception("Bu login band");
        }
        
        var innExists = await _organizationRepository.AnyAsync( o => o.Inn == dto.Inn);
        if(innExists)
        {
            throw new Exception("Bu STIR bilan tashkilot ro’yxatdan o’tgan");
        }

        var organization = new Organization
        {
            Name = dto.OrganizationName,
            Inn = dto.Inn,
            Address = dto.Address,
            PhoneNumber = dto.OrganizationPhoneNumber
        };

        throw new NotImplementedException();

    }
}
