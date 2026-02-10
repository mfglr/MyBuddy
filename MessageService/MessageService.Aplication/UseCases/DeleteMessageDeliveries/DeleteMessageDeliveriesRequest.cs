using MediatR;

namespace MessageService.Aplication.UseCases.DeleteMessageDeliveries
{
    internal record DeleteMessageDeliveriesRequest(IEnumerable<Guid> MessagesIds) : IRequest;
}
