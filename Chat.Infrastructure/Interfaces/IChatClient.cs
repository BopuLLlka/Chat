using Chat.Infrastructure.Models;

namespace Chat.Infrastructure.Interfaces
{
    public interface IChatClient
    {
        Task ReceiveMessage(User user, Message message);
    }
}
