using MediatR;

namespace RealtimeService.Application.UseCases.SendMessage
{
    public record SendMessageRequest_Message(string Content, Guid ReceiverId);
    public record SendMessageRequest(IEnumerable<SendMessageRequest_Message> Messages) : IRequest;
}
