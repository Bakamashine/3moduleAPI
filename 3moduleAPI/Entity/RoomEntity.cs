namespace _3moduleAPI.Entity;

public class RoomEntity(bool status)
{
    public Guid Id { set; get; }
    public bool Status { set; get; } = status;


    public List<BlockEnity> Blocks { set; get; } = new();

    public static RoomEntity Create(bool status) => new(status);
}