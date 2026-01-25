using System.ComponentModel.DataAnnotations;
using _3moduleAPI.Validation;

namespace _3moduleAPI.Contracts.Users;

public class RegisterUserRequest
{
    [Required]
    [StringLength(25)]
    [UniqueName]
    public required string Name { set; get; }

    [Required] [MinLength(8)] public required string Password { get; set; }

    [Required]
    [Compare("Password")]
    [MinLength(8)]
    public required string PasswordConfirmed { set; get; }
}