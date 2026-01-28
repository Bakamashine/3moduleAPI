namespace _3moduleAPI.Contracts.Block
{
    public class ReplaceBlock
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
