namespace MessageService.Domain.ConnectionAggregate
{
    public class Connection
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public DateTime LastConnectedAt { get; private set; }
        public string? ConenctionId { get; private set; }

        public Connection(Guid id)
        {
            Id = id;
            Version = 1;
        }

        public void Connect(string connectionId)
        {
            ConenctionId = connectionId;
            Version++;
        }

        public void Disconnect()
        {
            ConenctionId = null;
            LastConnectedAt = DateTime.UtcNow;
            Version++;
        }
    }
}
