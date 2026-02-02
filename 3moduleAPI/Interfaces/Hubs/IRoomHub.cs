
using _3moduleAPI.Dto;
using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Hubs
{
    public interface IRoomHub
    {
        Task ReceiveMessage(BlockDto data);
    }
}
