using RealtimeService.Api;
using RealtimeService.Api.Hubs;
using RealtimeService.Api.ServiceRegistrations;
using RealtimeService.Application;
using RealtimeService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services
    .AddScoped<IMessageRouter, MessageRouter>()
    .AddAutoMapper(builder.Configuration)
    .AddIdentity(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<RealtimeHub>("/realtime");
app.Run();
