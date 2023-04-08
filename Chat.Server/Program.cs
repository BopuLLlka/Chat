using Chat.Infrastructure.Models;
using Chat.Server.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddSingleton<MainHub>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapHub<MainHub>("/hub");

app.Run();
