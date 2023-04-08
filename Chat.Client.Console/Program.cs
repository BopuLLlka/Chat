using Chat.Client.Console.Services;

Console.WriteLine("Hello");

var signalRConnection = new SignalRService();


Console.WriteLine("Enter your name: ");
var userName = Console.ReadLine() ?? throw new ArgumentException("userName is null");

Console.WriteLine("Chat started");

while (true)
{
    var message = Console.ReadLine() ?? throw new ArgumentException("Message is null");
    await signalRConnection.SendMessage(userName, message);
}



