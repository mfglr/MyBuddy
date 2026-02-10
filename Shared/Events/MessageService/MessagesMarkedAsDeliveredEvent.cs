namespace Shared.Events.MessageService
{
    public record MessagesMarkedAsDeliveredEvent_MessageDelivery(
        Guid MessageId,
        Guid UserId,
        DateTime CreatedAt
    );

    public record MessagesMarkedAsDeliveredEvent(Guid UserId, IEnumerable<MessagesMarkedAsDeliveredEvent_MessageDelivery> Messages);
}
