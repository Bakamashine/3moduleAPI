using _3moduleAPI.Contracts.Repository;
using _3moduleAPI.Contracts.Users;
using _3moduleAPI.Dto;
using _3moduleAPI.Entity;
using _3moduleAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _3moduleAPI.Controller;

[ApiController]
public class UserController(
    ApplicationContext context,
    IPasswordHasherService passwordHasher,
    IJwtProvider jwtProvider,
    IUserRepository repository,
    ILogger<UserController> logger
)
    : ControllerBase
{
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        await context.Users.AddAsync(UserEntity.Create(request.Name, passwordHasher.PasswordHash(request.Password)));
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var user = await repository.GetByName(request.Name);
        // logger.LogDebug($"Login user: {user}");
        if (user == null || !passwordHasher.VerifyPassword(request.Password, user.Password))
            return NotFound();
        var token = jwtProvider.GenerateToken(user);
        return Ok(new LoginDto(token, user.Name));
    }


    [Authorize]
    [HttpGet("/test")]
    public string TestAuth()
    {
        return "Success Authorized!";
    }
}