using MyAsbo.Data.IRepositories;
using MyAsbo.Domain.Entities;
using MyAsbo.Domain.Enums;
using MyAsbo.Service.DTOs.Auth;
using MyAsbo.Service.DTOs.Users;
using MyAsbo.Service.Helpers;
using MyAsbo.Service.Interfaces;
using System.Security.Cryptography.X509Certificates;

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
        var user = await _userRepository.SelectAsync(u => u.Login == dto.Login);
        if(user is null)
        {
            throw new Exception("Login yoki parol noto'g'ri");
        }

        if (!PasswordHelper.Verify(dto.Password, user.PasswordHash))
        {
            throw new Exception("Login yoki parol noto'g'ri");
        }

        return _tokenService.GenerateToken(user);

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

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            Login = dto.Login,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash = PasswordHelper.Hash(dto.Password),
            Role = UserRole.Director,
            Organization = organization,
        };

        await _userRepository.InsertAsync(user);
        await _userRepository.SaveChangesAsync();

        return new UserResultDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName= user.LastName,
            MiddleName= user.MiddleName,
            Login= user.Login,
            PhoneNumber= user.PhoneNumber,
            Role = user.Role,
            IsActive = user.IsActive,
            OrganizationId = user.OrganizationId,
        };

    }
}
