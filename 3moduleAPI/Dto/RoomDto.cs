namespace _3moduleAPI.Dto
{
    public class RoomDto
    {
        public RoomDto(Guid id, bool status)
        {
            Id = id;
            Status = status;
        }

        public RoomDto()
        {
        }

        public Guid Id { get; set; }
        public bool Status { get; set; }
    }
}
