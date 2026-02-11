namespace Shared.Events.MessageService
{
    public record MessageCreatedEvent_Message(string Content, Guid SenderId, Guid ReceiverId);
    public record MessageCreatedEvent(IEnumerable<MessageCreatedEvent_Message> Messages);
}
