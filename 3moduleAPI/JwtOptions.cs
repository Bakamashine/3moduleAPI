using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace _3moduleAPI
{
    public class JwtOptions
    {

        public string SecretKey { get; } = "secretkeysecretkeysecretkeysecretkeysecretkey";
        public DateTime Time { get; } = DateTime.UtcNow.AddHours(12);
        public string Issuer { get; } = "BackendApp";
        public string Audience { get; } = "Frontend"; 

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        }
    }
}
