using _3moduleAPI.Contracts.Repository;
using _3moduleAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI.Repository;

public class RoomRepository(ApplicationContext context) : IRoomRepository
{
    public async Task<RoomEntity?> GetById(Guid id, bool noTracking = true)
    {
        RoomEntity room;
        if (noTracking)
            return await context
                .Room
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);
        
        return await context
            .Room
            .FirstOrDefaultAsync(entity => entity.Id == id);
    }
}