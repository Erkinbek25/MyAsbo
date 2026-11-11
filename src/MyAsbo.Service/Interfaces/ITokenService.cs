using MyAsbo.Domain.Entities;

namespace MyAsbo.Service.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
        
}
