
using Chat.Infrastructure.Interfaces;
using Chat.Infrastructure.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client.Console.Services
{
    public class SignalRService
    {
        private HubConnection _connection;

        public SignalRService() {
            _connection = new HubConnectionBuilder().WithAutomaticReconnect().WithUrl("https://localhost:7047/hub").Build();

            _connection.StartAsync().Wait();

            _connection.On("ReceiveMessage", (User user, Message message) =>
            {
                System.Console.WriteLine($"{user.Name}: {message.Text}");
            });
        }

        public async Task SendMessage(string userName, string messageText)
        {
            await _connection.InvokeAsync("SendMessage", new User { Name = userName }, new Message { Text = messageText });
        }

        
    }
}
