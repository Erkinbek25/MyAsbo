using MyAsbo.Domain.Entities;

namespace MyAsbo.Service.Intefaces;

public interface ITokenService
{
    string GenerateToken(User user);
        
}
