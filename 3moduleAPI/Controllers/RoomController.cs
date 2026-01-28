using _3moduleAPI.Dto;
using _3moduleAPI.Entity;
using _3moduleAPI.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3moduleAPI.Controller;

[ApiController]
[Route("room")]
public class RoomController(ApplicationContext context, IRoomRepository repository) : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> Store()
    {
        await context.Room.AddAsync(RoomEntity.Create(true));
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("stop/{id:guid}")]
    public async Task<IActionResult> StopRoom(Guid id)
    {
        var room = await repository.GetById(id, false);
        if (room == null) return NotFound();
        room.Status = false;
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllRoom()
    {
        var rooms = await context.Room.Include(m => m.Blocks).ToListAsync();
        return Ok(rooms);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoomWithoutBlocks()
    {
        var rooms = await context.Room.AsNoTracking().ToListAsync();
        var roomsDto = rooms.Select(m => new RoomDto
        {
            Id = m.Id,
            Status = m.Status
        }).ToList();
        return Ok(roomsDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        var room = await repository.GetByIdWithBlock(id);
        if (room == null) return NotFound();
        return Ok(room);
    }
}