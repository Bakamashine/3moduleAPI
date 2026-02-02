using _3moduleAPI.Interfaces.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace _3moduleAPI.Hubs
{
    public class RoomHub : Hub<IRoomHub>
    {

        public async Task JoinRoom(string roomId)
        {
            Console.WriteLine($"JOIN ROOM: {roomId}, ConnId: {Context.ConnectionId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task LeaveRoom(string roomId)
        {
            Console.WriteLine($"LEAVE ROOM: {roomId}, ConnId: {Context.ConnectionId}");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
