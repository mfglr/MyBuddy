namespace RealtimeService.Domain
{
    public class Connection(Guid id)
    {
        public Guid Id { get; private set; } = id;
        public DateTime? LastConnectedAt { get; private set; }
        public string? ConnectionId { get; private set; }

        public void Connect(string connectionId) => ConnectionId = connectionId;

        public void Disconnect()
        {
            ConnectionId = null;
            LastConnectedAt = DateTime.UtcNow;
        }

    }
}
