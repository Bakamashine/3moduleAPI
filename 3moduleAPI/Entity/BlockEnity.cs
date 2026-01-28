using System.Text.Json.Serialization;

namespace _3moduleAPI.Entity
{
    public class BlockEnity(int x, int y, int width, int height, Guid roomId, string color = "red")
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RoomId { get; set; } = roomId;
        [JsonIgnore]
        public RoomEntity Room { get; set; } = null!;
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Width { get; set; } = width;
        public int Height { get; set; } = height;
        public string Color { get; set; } = color;
    }
}
