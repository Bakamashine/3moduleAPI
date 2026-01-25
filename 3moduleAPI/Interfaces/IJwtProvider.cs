using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces;

public interface IJwtProvider
{
    public string GenerateToken(UserEntity user);
}