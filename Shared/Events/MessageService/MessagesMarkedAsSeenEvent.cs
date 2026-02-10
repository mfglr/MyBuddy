namespace Shared.Events.MessageService
{
    public record MessagesMarkedAsSeenEvent_Message(
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
    public record MessagesMarkedAsSeenEvent(Guid UserId, IEnumerable<MessagesMarkedAsSeenEvent_Message> Messages);
}
