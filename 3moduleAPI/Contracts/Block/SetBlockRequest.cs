using System.ComponentModel.DataAnnotations;

namespace _3moduleAPI.Contracts.Block
{
    public class SetBlockRequest
    {
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public string Color { get; set; } = null!;
    }
}
