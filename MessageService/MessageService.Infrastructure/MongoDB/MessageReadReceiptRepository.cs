using MessageService.Domain.MessageReadReceiptAggregate;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDB
{
    internal class MessageReadReceiptRepository(MongoContext context) : IMessageReadReceiptRepository
    {
        public Task CreateAsync(IEnumerable<MessageReadReceipt> messageReadReceipts, CancellationToken cancellationToken) =>
            context.MessageReadReceipts.InsertManyAsync(messageReadReceipts, cancellationToken: cancellationToken);

        public Task DeleteAsync(IEnumerable<MessageReadReceipt> messageReadReceipts, CancellationToken cancellationToken)
        {
            var filter = Builders<MessageReadReceipt>.Filter.In(x => x.MessageId, messageReadReceipts.Select(x => x.MessageId));
            return context.MessageReadReceipts.DeleteManyAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<bool> ExistAsync(Guid messageId, Guid userId, CancellationToken cancellationToken)
        {
            var filter =
                Builders<MessageReadReceipt>.Filter.And(
                    Builders<MessageReadReceipt>.Filter.Eq(x => x.MessageId, messageId),
                    Builders<MessageReadReceipt>.Filter.Eq(x => x.UserId, userId)
                );
            var result = await context.MessageReadReceipts.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.AnyAsync(cancellationToken);
        }

        public async Task<IEnumerable<MessageReadReceipt>> GetByMessageIds(IEnumerable<Guid> messageIds, CancellationToken cancellationToken)
        {
            var filter = Builders<MessageReadReceipt>.Filter.In(x => x.MessageId, messageIds);
            var result = await context.MessageReadReceipts.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }
    }
}
