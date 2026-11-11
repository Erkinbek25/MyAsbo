using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyAsbo.Domain.Entities;
using MyAsbo.Service.Interfaces;
using MyAsbo.Service.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
        

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

        var credantials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            claims: claims,
            signingCredentials: credantials,
            audience: _options.Audience, 
            expires: DateTime.Now);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
