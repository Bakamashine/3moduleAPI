using _3moduleAPI.Contracts.Block;
using _3moduleAPI.Entity;
using _3moduleAPI.Hubs;
using _3moduleAPI.Interfaces.Hubs;
using _3moduleAPI.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if (roomRepository.GetById(request.RoomId) == null)
            {
                return NotFound("Room not found");
            }
            var block = await repository.Create(new BlockEnity(request.X, request.Y, request.Width, request.Height, request.RoomId, request.Color));
            //await hubContext.Clients.Group(request.RoomId.ToString())
            //    .BlockCreated(block);
            await hubContext.Clients.Group(request.RoomId.ToString()).ReceiveMessage(block);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult?> ReplaceBlock([FromBody] ReplaceBlock request)
        {
            var block = await repository.GetById(request.Id);
            if (block == null) return NotFound();
            var newBlock = await repository.UpdateSizeAndPosition(block, request.X, request.Y, request.Width, request.Height);
            await hubContext.Clients.Group(request.RoomId.ToString())
                .ReceiveMessage(newBlock);

            return NoContent();
        }

    }
}
