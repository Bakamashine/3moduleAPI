using _3moduleAPI.Entity;
using _3moduleAPI.Interfaces.Providers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _3moduleAPI;

public class JwtProvider(JwtOptions _jwtOptions) : IJwtProvider
{
    public string GenerateToken(UserEntity user)
    {
        Claim[] claims =
        [
            new("userId", user.Id.ToString()),
            new("name", user.Name)
        ];

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: _jwtOptions.Time
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}