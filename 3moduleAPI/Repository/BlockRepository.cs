using _3moduleAPI.Entity;
using _3moduleAPI.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI.Repository
{
    public class BlockRepository(ApplicationContext context) : IBlockRepository
    {
        public async Task<bool> CheckUniqueBlock(BlockEnity entity, Guid roomId)
        {
            //return await context
            //    .Block
            //    .AsNoTracking()
            //    .Where(block => block.RoomId == roomId && )
            //    .AnyAsync();

            throw new NotImplementedException();
        }

        public async Task<BlockEnity> Create(BlockEnity entity)
        {
            var response = await context.Block.AddAsync(entity);
            await context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<BlockEnity?> GetById(Guid id)
        {
            return await context
                .Block
                .AsNoTracking()
                .FirstOrDefaultAsync(block => block.Id == id);
        }

        public async Task<List<BlockEnity>> GetByIdRoom(Guid roomId)
        {
            return await context
                .Block
                .AsNoTracking()
                .Where(block => block.RoomId == roomId)
                .ToListAsync();
        }


        public async Task<BlockEnity> UpdateSizeAndPosition(BlockEnity entity, int x, int y, int width, int height)
        {
            entity.X = x;
            entity.Y = y;
            entity.Width = width;
            entity.Height = height;
            var response = context.Block.Update(entity);
            await context.SaveChangesAsync();
            return response.Entity;
        }
    }
}
