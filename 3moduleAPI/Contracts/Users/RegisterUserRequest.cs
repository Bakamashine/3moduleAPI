using _3moduleAPI.Validation;
using System.ComponentModel.DataAnnotations;

namespace _3moduleAPI.Contracts.Users;

public class RegisterUserRequest
{
    [Required]
    [StringLength(25)]
    [UniqueName]
    public string Name { set; get; } = null!;

    [Required][MinLength(8)] public string Password { set; get; } = null!;

    [Required]
    [Compare("Password")]
    [MinLength(8)]
    public string PasswordConfirmed { set; get; } = null!;
}