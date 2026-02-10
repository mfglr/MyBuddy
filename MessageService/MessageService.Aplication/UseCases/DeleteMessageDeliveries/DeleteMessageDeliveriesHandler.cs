using MediatR;
using MessageService.Domain.MessageDeliveryAggregate;

namespace MessageService.Aplication.UseCases.DeleteMessageDeliveries
{
    internal class DeleteMessageDeliveriesHandler(IMessageDeliveryRepository messageDeliveryRepository) : IRequestHandler<DeleteMessageDeliveriesRequest>
    {
        public async Task Handle(DeleteMessageDeliveriesRequest request, CancellationToken cancellationToken)
        {
            var messageDeliveries = await messageDeliveryRepository.GetByMessageIdsAsync(request.MessagesIds, cancellationToken);
            await messageDeliveryRepository.DeleteAsync(messageDeliveries, cancellationToken);
        }
    }
}
