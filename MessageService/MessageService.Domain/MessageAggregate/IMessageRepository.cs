namespace MessageService.Domain.MessageAggregate
{
    public interface IMessageRepository
    {
        Task<Message?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Message>> GetBySenderIdAsync(Guid senderId, CancellationToken cancellationToken);
        Task<List<Message>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
        Task CreateAsync(Message message, CancellationToken cancellationToken);
        Task DeleteAsync(Message mesasge,CancellationToken cancellationToken);
        Task DeleteAsync(IEnumerable<Message> messages, CancellationToken cancellationToken);
    }
}
