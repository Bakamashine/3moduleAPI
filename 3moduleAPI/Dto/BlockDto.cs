using _3moduleAPI.Entity;

namespace _3moduleAPI.Dto;

public class BlockDto
{
    public BlockDto(Guid id, int x, int y, int width, int height, string color)
    {
        this.Id = id;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Color = color;
    }

    public BlockDto(BlockEnity entity)
    {
        Id = entity.Id;
        X = entity.X;
        Y = entity.Y;
        Width = entity.Width;
        Height = entity.Height;
        Color = entity.Color;
    }
    public Guid Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Color { get; set; } = null!;

    public static BlockDto Convert(BlockEnity entity) => new(entity);
}