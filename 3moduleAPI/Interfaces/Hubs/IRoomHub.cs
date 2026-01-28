
using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Hubs
{
    public interface IRoomHub
    {
        Task ReceiveMessage(BlockEnity entity);
    }
}
