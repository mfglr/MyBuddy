using MediatR;

namespace MessageService.Application.UseCases.DeleteMessage
{
    public record DeleteMessageRequest(IEnumerable<Guid> Ids) : IRequest;
}
