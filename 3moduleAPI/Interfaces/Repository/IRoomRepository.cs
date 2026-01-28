using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Repository;

public interface IRoomRepository
{
    public Task<RoomEntity?> GetById(Guid id, bool noTracking = true);
    public Task<RoomEntity?> GetByIdWithBlock(Guid id);

}