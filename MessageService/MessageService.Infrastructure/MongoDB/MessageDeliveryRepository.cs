using MessageService.Domain.MessageDeliveryAggregate;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDB
{
    internal class MessageDeliveryRepository(MongoContext context) : IMessageDeliveryRepository
    {
        public Task CreateAsync(IEnumerable<MessageDelivery> messageDeliveries, CancellationToken cancellationToken) =>
            context.MessageDeliveries.InsertManyAsync(messageDeliveries, cancellationToken: cancellationToken);

        public Task DeleteAsync(IEnumerable<MessageDelivery> messageDeliveries, CancellationToken cancellationToken)
        {
            var filter = Builders<MessageDelivery>.Filter.In(x => x.MessageId, messageDeliveries.Select(x => x.MessageId));
            return context.MessageDeliveries.DeleteManyAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<bool> ExistAsync(Guid messageId, Guid userId, CancellationToken cancellationToken)
        {
            var filter =
                Builders<MessageDelivery>.Filter.And(
                    Builders<MessageDelivery>.Filter.Eq(x => x.MessageId, messageId),
                    Builders<MessageDelivery>.Filter.Eq(x => x.UserId, userId)
                );
            var document = await context.MessageDeliveries.FindAsync(filter, cancellationToken: cancellationToken);
            return await document.AnyAsync(cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<MessageDelivery>> GetByMessageIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var filter = Builders<MessageDelivery>.Filter.In(x => x.MessageId, ids);
            var document = await context.MessageDeliveries.FindAsync(filter, cancellationToken: cancellationToken);
            return await document.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
