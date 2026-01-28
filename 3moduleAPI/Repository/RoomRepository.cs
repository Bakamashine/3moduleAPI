using _3moduleAPI.Entity;
using _3moduleAPI.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI.Repository;

public class RoomRepository(ApplicationContext context) : IRoomRepository
{
    public async Task<RoomEntity?> GetById(Guid id, bool noTracking = true)
    {
        if (noTracking)
            return await context
                .Room
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);

        return await context
            .Room
            .FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<RoomEntity?> GetByIdWithBlock(Guid id)
    {
        return await context
            .Room
            .AsNoTracking()
            .Include(entity => entity.Blocks)
            .FirstOrDefaultAsync(entity => entity.Id == id);
    }
}