using MediatR;

namespace MessageService.Aplication.UseCases.SendMessage
{
    public record SendMessageRequest_Message(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        Guid SenderId,
        Guid ReceiverId,
        string Content,
        DateTime? ReceivedAt,
        DateTime? SeenAt
    );
    public record SendMessageRequest(
        Guid UserId,
        IEnumerable<SendMessageRequest_Message> Messages
    ) : IRequest;
}
