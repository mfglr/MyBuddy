namespace Shared.Events.MessageService
{
    public record MessageContentUpdatedEvent(
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
}
