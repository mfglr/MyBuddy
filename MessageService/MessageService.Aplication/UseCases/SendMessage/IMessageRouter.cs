using MessageService.Domain.ConnectionAggregate;
using MessageService.Domain.MessageDeliveryAggregate;
using MessageService.Domain.MessageReadReceiptAggregate;

namespace MessageService.Aplication.UseCases.SendMessage
{
    public interface IMessageRouter
    {
        Task SendMessageAsync(IEnumerable<MessageResponse> messages, Connection connection, CancellationToken cancellationToken);
        Task SendMessageDeliveryAsync(IEnumerable<MessageDelivery> messageDeliveries, Connection connection, CancellationToken cancellationToken);
        Task SendMessageReadRecieptsAsync(IEnumerable<MessageReadReceipt> messageReadReceipts, Connection connection, CancellationToken cancellationToken);
    }
}
