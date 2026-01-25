using _3moduleAPI.Entity;

namespace _3moduleAPI.Contracts.Repository;

public interface IUserRepository
{
    public Task<UserEntity?> GetByName(string name);
}