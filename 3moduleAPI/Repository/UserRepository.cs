using _3moduleAPI.Contracts.Repository;
using _3moduleAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI.Repository;

public class UserRepository(ApplicationContext context) : IUserRepository
{
    public async Task<UserEntity?> GetByName(string name)
    {
        return await context.Users.AsNoTracking()
            .FirstOrDefaultAsync(user =>
                name == user.Name);
    }
}