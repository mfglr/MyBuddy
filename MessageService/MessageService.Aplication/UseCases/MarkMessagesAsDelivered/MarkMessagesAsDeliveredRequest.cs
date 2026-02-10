using MediatR;

namespace MessageService.Aplication.UseCases.MarkMessagesAsDelivered
{
    public record MarkMessagesAsDeliveredRequest(IEnumerable<Guid> Ids) : IRequest;
}
