namespace MessageService.Domain.MessageReadReceiptAggregate
{
    public class MessageReadReceipt(Guid messageId, Guid userId)
    {
        public Guid MessageId { get; private set; } = messageId;
        public Guid UserId { get; private set; } = userId;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
