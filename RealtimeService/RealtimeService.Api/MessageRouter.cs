using Microsoft.AspNetCore.SignalR;
using RealtimeService.Api.Hubs;
using RealtimeService.Application;
using RealtimeService.Domain;

namespace RealtimeService.Api
{
    public class MessageRouter(IHubContext<RealtimeHub> hub) : IMessageRouter
    {
        public Task SendAsync(IEnumerable<string> contents, Connection connection, CancellationToken cancellationToken = default)
        {
            if (connection.ConnectionId == null) return Task.CompletedTask;
            return hub.Clients.Client(connection.ConnectionId).SendAsync("receiveMessage", contents, cancellationToken);
        }
    }
}
