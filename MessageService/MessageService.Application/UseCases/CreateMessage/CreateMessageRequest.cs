using MediatR;

namespace MessageService.Application.UseCases.CreateMessage
{
    public record CreateMessageRequest_Message(string Content, Guid ReceiverId);
    public record CreateMessageRequest(IEnumerable<CreateMessageRequest_Message> Messages) : IRequest;
}
