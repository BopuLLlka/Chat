using Microsoft.AspNetCore.SignalR;

namespace Chat.Server
{
    public class MainHub : Hub
    {
        public async Task SendMessage(string user, string message)
    => await Clients.All.ReceiveMessage(user, message);

        public async Task SendMessageToCaller(string user, string message)
            => await Clients.Caller.ReceiveMessage(user, message);

        public async Task SendMessageToGroup(string user, string message)
            => await Clients.Group("SignalR Users").ReceiveMessage(user, message);

    }
}
