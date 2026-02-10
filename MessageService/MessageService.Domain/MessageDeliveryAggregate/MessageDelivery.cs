namespace MessageService.Domain.MessageDeliveryAggregate
{
    public class MessageDelivery(Guid messageId, Guid userId)
    {
        public Guid MessageId { get; private set; } = messageId;
        public Guid UserId { get; private set; } = userId;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
