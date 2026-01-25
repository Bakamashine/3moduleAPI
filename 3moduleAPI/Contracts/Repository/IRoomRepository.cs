using _3moduleAPI.Entity;

namespace _3moduleAPI.Contracts.Repository;

public interface IRoomRepository
{
    public Task<RoomEntity?> GetById(Guid id, bool noTracking = true);
}