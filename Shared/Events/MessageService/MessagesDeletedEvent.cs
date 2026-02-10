namespace Shared.Events.MessageService
{
    public record MessagesDeletedEvent(IEnumerable<Guid> MessagesIds);
}
