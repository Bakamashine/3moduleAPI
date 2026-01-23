using _3moduleAPI.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace _3moduleAPI.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(UserEntity user);

      

    }
}
