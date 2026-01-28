using _3moduleAPI.Interfaces.Services;
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

    public static string PasswordHashStatic(string password)
    {
        return HashPassword(password);
    }

}