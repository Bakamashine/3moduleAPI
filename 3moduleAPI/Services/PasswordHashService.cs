using _3moduleAPI.Interfaces;
using static BCrypt.Net.BCrypt;

namespace _3moduleAPI.Service;

public class PasswordHashService : IPasswordHasherService
{
    public string PasswordHash(string password)
    {
        return HashPassword(password);
    }

    public bool VerifyPassword(string password, string secondPasswordHash)
    {
        return Verify(password, secondPasswordHash);
    }
}