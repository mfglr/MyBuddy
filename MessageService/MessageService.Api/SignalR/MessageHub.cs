using MediatR;
using MessageService.Aplication.UseCases.Connect;
using MessageService.Aplication.UseCases.CreateMessage;
using MessageService.Aplication.UseCases.Disconnect;
using MessageService.Aplication.UseCases.GetConnectionStatus;
using MessageService.Aplication.UseCases.GetUnreceivedMessages;
using MessageService.Aplication.UseCases.MarkMessagesAsDelivered;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace MessageService.Api.SignalR
{
    [Authorize("user")]
    public class MessageHub(ISender sender) : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await sender.Send(new ConnectRequest(Context.ConnectionId));
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
            await sender.Send(new DisconnectRequest());
        }

        public Task<GetConnectionStatusByIdResponse> GetConnectionStatusById(Guid id) =>
            sender.Send(new GetConnectionStatusByIdRequest(id));

        public Task<GetUnreceivedMessagesResponse> GetUnreceivedMessages(GetUnreceivedMessagesRequest request) =>
            sender.Send(request);
        
        public Task<CreateMessageResponse> CreateMessage(CreateMessageRequest request) =>
            sender.Send(request);
        
        public Task MarkMessagesAsReceived(MarkMessagesAsDeliveredRequest request) =>
            sender.Send(request);
    }
}
