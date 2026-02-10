using MediatR;

namespace MessageService.Aplication.UseCases.DeleteMessageReadReceipts
{
    public record DeleteMessageReadReceiptsRequest(IEnumerable<Guid> MessageIds) : IRequest;
}
