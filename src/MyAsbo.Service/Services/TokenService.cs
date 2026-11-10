using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyAsbo.Domain.Entities;
using MyAsbo.Service.Interfaces;
using MyAsbo.Service.Options;
using System.Security.Claims;

namespace MyAsbo.Service.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _options;
    public TokenService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        throw new NotImplementedException();

    }
}
