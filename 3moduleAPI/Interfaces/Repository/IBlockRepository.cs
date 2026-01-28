using _3moduleAPI.Entity;

namespace _3moduleAPI.Interfaces.Repository
{
    public interface IBlockRepository
    {
        public Task<List<BlockEnity>> GetByIdRoom(Guid roomId);
        public Task<BlockEnity?> GetById(Guid id);
        public Task<BlockEnity> Create(BlockEnity entity);

        public Task<BlockEnity> UpdateSizeAndPosition(BlockEnity entity, int x, int y, int width, int height);

        public Task<bool> CheckUniqueBlock(BlockEnity entity, Guid roomId);
    }
}
