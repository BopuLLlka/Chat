using Chat.Server.SignalR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapGet("/GetUserWithMessage", ([FromQuery] string name) => {
    var hub = new MainHub();


    var newString = hub.GetUserWithMessage($"UserName: {name}", " Message: Message123123123");

    return newString;
});

app.MapGet("/Hello", ([FromQuery] string name) => $"Hello: {name}!");
app.MapPost("/HelloPost", () =>
{

    //var client = JsonSerializer.Deserialize<Client>(clientString);

    //return client.Name;

    return "123";
});


app.MapHub<MainHub>("Chat");


app.Run();

public class Client
{
    public string Name { get; set; }
    public string Age { get; set; }
}
