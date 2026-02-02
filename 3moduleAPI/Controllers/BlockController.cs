using _3moduleAPI.Contracts.Block;
using _3moduleAPI.Dto;
using _3moduleAPI.Entity;
using _3moduleAPI.Hubs;
using _3moduleAPI.Interfaces.Hubs;
using _3moduleAPI.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;


namespace _3moduleAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("block")]
    public class BlockController(IBlockRepository repository, IHubContext<RoomHub, IRoomHub> hubContext, IRoomRepository roomRepository) : ControllerBase
    {
        [HttpGet("getByRoom/{roomId:guid}")]
        public async Task<IActionResult> GetBlocksByRoom(Guid roomId)
        {
            var response = await repository.GetByIdRoom(roomId);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBlockById(Guid id)
        {
            var response = await repository.GetById(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SetBlock([FromBody] SetBlockRequest request)
        {
            string[] colors = ["red", "blue", "white"];
            // Random rand = new();
            string randomColor = colors[new Random().Next(colors.Length)];
            
            var room = await roomRepository.GetById(request.RoomId);
            if (room == null)
            {
                return NotFound("Room not found");
            }
            BlockEnity? block = await repository.Create(new BlockEnity(
                0, 0, 100, 100, request.RoomId, randomColor
            ));
            Console.WriteLine($"Created block with ID: {block.Id} in Room ID: {request.RoomId}");
            await hubContext.Clients.Group(room.Id.ToString()).AddItem(BlockDto.Convert(block));
            return Ok(block);
        }

        [HttpPut]
        public async Task<IActionResult?> ReplaceBlock([FromBody] ReplaceBlock request)
        {
            var block = await repository.GetById(request.Id);
            if (block == null) return NotFound();
            var newBlock = await repository.UpdateSizeAndPosition(block, request.X, request.Y, request.Width, request.Height);
            await hubContext.Clients.Group(newBlock.RoomId.ToString()).UpdateItem(BlockDto.Convert(newBlock));

            // await hubContext.Clients.Group(newBlock.RoomId.ToString()).SUS("sus");

            return NoContent();
        }

    }
}
