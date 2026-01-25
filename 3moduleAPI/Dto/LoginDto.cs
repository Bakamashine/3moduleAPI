namespace _3moduleAPI.Dto;

public class LoginDto(string token, string name)
{
    public string Token { set; get; } = token;
    public string Name { set; get; } = name;
}