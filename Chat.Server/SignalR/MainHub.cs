using Chat.Infrastructure.Interfaces;
using Chat.Infrastructure.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace Chat.Server.SignalR
{
    public class MainHub : Hub
    {
        public async Task SendMessage(User user, Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
