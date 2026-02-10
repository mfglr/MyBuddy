namespace MessageService.Domain.MessageDeliveryAggregate
{
    public interface IMessageDeliveryRepository
    {
        Task<bool> ExistAsync(Guid messageId, Guid userId, CancellationToken cancellationToken);
        Task<IEnumerable<MessageDelivery>> GetByMessageIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
        Task CreateAsync(IEnumerable<MessageDelivery> messageDeliveries, CancellationToken cancellationToken);
        Task DeleteAsync(IEnumerable<MessageDelivery> messageDeliveries, CancellationToken cancellationToken);
    }
}
