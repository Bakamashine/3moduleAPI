
using _3moduleAPI.Dto;
using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Hubs
{
    public interface IRoomHub
    {
        Task AddItem(BlockDto data);
        Task UpdateItem(BlockDto data);
    }
}
