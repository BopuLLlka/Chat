using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.SignalR
{
    public class MainHub : Hub<IChatClient>
    {
        public async Task SendMessage(string user, string message) => await Clients.All.ReceiveMessage(user, message);
        
        public string GetUserWithMessage(string user, string message) =>  user + message;

    }
}
