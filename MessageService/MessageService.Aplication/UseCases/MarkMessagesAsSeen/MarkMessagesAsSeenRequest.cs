using MediatR;

namespace MessageService.Aplication.UseCases.MarkMessagesAsSeen
{
    public record MarkMessagesAsSeenRequest(IEnumerable<Guid> Ids) : IRequest;
}
