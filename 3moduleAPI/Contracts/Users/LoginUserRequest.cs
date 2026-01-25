using System.ComponentModel.DataAnnotations;

namespace _3moduleAPI.Contracts.Users;

public class LoginUserRequest
{
    [Required] public required string Name { set; get; }

    [Required] public required string Password { set; get; }
}