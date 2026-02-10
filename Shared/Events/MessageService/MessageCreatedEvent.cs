namespace Shared.Events.MessageService
{
    public record MessageCreatedEvent(
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
