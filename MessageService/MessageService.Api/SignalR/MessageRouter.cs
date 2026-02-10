using MessageService.Aplication.UseCases.SendMessage;
using MessageService.Domain.ConnectionAggregate;
using MessageService.Domain.MessageDeliveryAggregate;
using MessageService.Domain.MessageReadReceiptAggregate;
using Microsoft.AspNetCore.SignalR;

namespace MessageService.Api.SignalR
{
    public class MessageRouter(IHubContext<MessageHub> hub) : IMessageRouter
    {
        public Task SendMessageAsync(IEnumerable<MessageResponse> messages, Connection connection, CancellationToken cancellationToken)
        {
            if(connection.ConenctionId != null)
                return hub.Clients
                    .Client(connection.ConenctionId)
                    .SendAsync("receiveMessage", messages, cancellationToken);
            return Task.CompletedTask;
        }

        public Task SendMessageDeliveryAsync(IEnumerable<MessageDelivery> messageDeliveries, Connection connection, CancellationToken cancellationToken)
        {
            if (connection.ConenctionId != null)
                return hub.Clients
                    .Client(connection.ConenctionId)
                    .SendAsync("receiveMessageDelivery", messageDeliveries, cancellationToken);
            return Task.CompletedTask;
        }

        public Task SendMessageReadRecieptsAsync(IEnumerable<MessageReadReceipt> messageReadReceipts, Connection connection, CancellationToken cancellationToken)
        {
            if (connection.ConenctionId != null)
                return hub.Clients
                    .Client(connection.ConenctionId)
                    .SendAsync("receiveMessageReadReceipts", messageReadReceipts, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
