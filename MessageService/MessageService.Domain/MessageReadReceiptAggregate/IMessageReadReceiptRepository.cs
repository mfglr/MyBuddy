namespace MessageService.Domain.MessageReadReceiptAggregate
{
    public interface IMessageReadReceiptRepository
    {
        Task<IEnumerable<MessageReadReceipt>> GetByMessageIds(IEnumerable<Guid> messageIds, CancellationToken cancellationToken);
        Task<bool> ExistAsync(Guid messageId, Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(IEnumerable<MessageReadReceipt> messageReadReceipts, CancellationToken cancellationToken);
        Task DeleteAsync(IEnumerable<MessageReadReceipt> messageReadReceipts, CancellationToken cancellationToken);
    }
}
