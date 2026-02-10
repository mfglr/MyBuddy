namespace MessageService.Domain.MessageAggregate
{
    public class Message(Guid senderId, Guid receiverId, Content content)
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid SenderId { get; private set; } = senderId;
        public Guid ReceiverId { get; private set; } = receiverId;
        public Content Content { get; private set; } = content ?? throw new ContentRequiredException();
    }
}
