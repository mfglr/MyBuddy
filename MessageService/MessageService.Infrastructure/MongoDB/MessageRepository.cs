using MessageService.Domain.MessageAggregate;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDB
{
    internal class MessageRepository(MongoContext context) : IMessageRepository
    {
        public async Task<Message?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Message>.Filter.Eq(x => x.Id, id);
            var document = await context.Messages.FindAsync(filter, cancellationToken: cancellationToken);
            return await document.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
        public async Task<List<Message>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var filter = Builders<Message>.Filter.In(x => x.Id, ids);
            var document = await context.Messages.FindAsync(filter, cancellationToken: cancellationToken);
            return await document.ToListAsync(cancellationToken: cancellationToken);
        }
        public Task CreateAsync(Message message, CancellationToken cancellationToken) =>
            context.Messages.InsertOneAsync(message, cancellationToken: cancellationToken);
        
        public Task DeleteAsync(Message message, CancellationToken cancellationToken)
        {
            var filter = Builders<Message>.Filter.Eq(x => x.Id, message.Id);
            return context.Messages.DeleteOneAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<List<Message>> GetBySenderIdAsync(Guid senderId, CancellationToken cancellationToken)
        {
            var filter = Builders<Message>.Filter.Eq(x => x.SenderId, senderId);
            var documents = await context.Messages.FindAsync(filter, cancellationToken: cancellationToken);
            return await documents.ToListAsync(cancellationToken: cancellationToken);
        }

        public Task DeleteAsync(IEnumerable<Message> messages, CancellationToken cancellationToken)
        {
            var filter = Builders<Message>.Filter.In(x => x.Id, messages.Select(x => x.Id));
            return context.Messages.DeleteManyAsync(filter, cancellationToken: cancellationToken);
        }
    }
}
