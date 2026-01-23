using _3moduleAPI.Contracts.Users;
using _3moduleAPI.Entity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace _3moduleAPI.Controller
{
    [ApiController]
    public class UserController(ApplicationContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await context.Users.AddAsync(UserEntity.Create(request.Name, request.Password));
            return Ok();
        }
    }
}
