using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RealtimeService.Application.UseCases.Connect;
using RealtimeService.Application.UseCases.Disconnect;
using RealtimeService.Application.UseCases.GetConnection;

namespace RealtimeService.Api.Hubs
{
    [Authorize("user")]
    public class RealtimeHub(ISender sender) : Hub
    {
        public override Task OnConnectedAsync() =>
            sender.Send(new ConnectRequest(Context.ConnectionId));

        public override Task OnDisconnectedAsync(Exception? exception) =>
            sender.Send(new DisconnectRequest());

        public Task<GetConnectionResponse> GetConnection(GetConnectionRequest request) =>
            sender.Send(request);
    }
}
