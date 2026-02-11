namespace MessageService.Domain
{
    public class Message(Content content, Guid senderId,  Guid receiverId)
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public Guid SenderId { get; private set; } = senderId;
        public Guid ReceiverId { get; private set; } = receiverId;
        public Content Content { get; private set; } = content;
    }
}
