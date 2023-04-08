using Chat.Client.Console.Services;

Console.WriteLine("Enter your name: ");
var userName = Console.ReadLine() ?? throw new ArgumentException("userName is null");

Console.WriteLine("Connecting to hub...");
var signalRConnection = new SignalRService();
Console.WriteLine("Connected");

Console.WriteLine("Chat started");

while (true)
{
    var message = Console.ReadLine() ?? throw new ArgumentException("Message is null");
    System.Console.SetCursorPosition(0, System.Console.CursorTop - 1);
    ClearCurrentConsoleLine();
    
    await signalRConnection.SendMessage(userName, message);
}

void ClearCurrentConsoleLine()
{
    int currentLineCursor = System.Console.CursorTop;
    System.Console.SetCursorPosition(0, System.Console.CursorTop);
    System.Console.Write(new string(' ', System.Console.WindowWidth));
    System.Console.SetCursorPosition(0, currentLineCursor);
}