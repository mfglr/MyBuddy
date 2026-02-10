using MessageService.Api.Identity;
using MessageService.Api.SignalR;
using MessageService.Aplication;
using MessageService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCustomSignalR()
    .AddIdentity(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<MessageHub>("/message");
app.Run();
