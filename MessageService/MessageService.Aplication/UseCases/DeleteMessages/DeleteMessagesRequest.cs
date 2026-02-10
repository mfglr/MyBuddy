using MediatR;

namespace MessageService.Aplication.UseCases.DeleteMessages
{
    public record DeleteMessagesRequest(IEnumerable<Guid> Ids) : IRequest;
}
