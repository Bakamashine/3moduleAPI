using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Repository;

public interface IUserRepository
{
    public Task<UserEntity?> GetByName(string name);
}