namespace MessageService.Domain
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<List<Message>> GetByReceiverIdAsync(Guid receiverId, Guid? cursor = null, int recordsPerPage = 100, CancellationToken cancellationToken = default);
        Task<List<Message>> GetExpiredMessagesAsync(TimeSpan timeSpan, CancellationToken cancellationToken = default);
        Task CreateAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default);
        Task DeleteAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default);
    }
}
