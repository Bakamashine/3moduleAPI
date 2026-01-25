using _3moduleAPI.Contracts.Repository;
using _3moduleAPI.Entity;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet()]
    public async Task<IActionResult> GetAllRoom()
    {
        var rooms = await context.Room.ToListAsync();
        return Ok(rooms);
    }
}