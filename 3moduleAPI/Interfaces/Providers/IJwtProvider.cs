using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Providers;

public interface IJwtProvider
{
    public string GenerateToken(UserEntity user);
}