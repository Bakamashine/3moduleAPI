namespace _3moduleAPI.Interfaces;

public interface IPasswordHasherService
{
    public string PasswordHash(string password);
    public bool VerifyPassword(string password, string secondPasswordHash);
}