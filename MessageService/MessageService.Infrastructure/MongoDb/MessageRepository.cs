using MessageService.Domain;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDb
{
    internal class MessageRepository(MongoContext context) : IMessageRepository
    {
        private readonly MongoContext _context = context;

        public  Task<List<Message>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Message>.Filter.In(c => c.Id, ids);
            return _context.Messages.Find(filter).ToListAsync(cancellationToken);
        }
        public Task<List<Message>> GetByReceiverIdAsync(Guid receiverId, Guid? cursor = null, int recordsPerPage = 100, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Message>.Filter.Eq(x => x.ReceiverId, receiverId);
            if (cursor != null)
                filter &= Builders<Message>.Filter.Gt(x => x.Id, cursor);

            return _context.Messages
                .Find(filter)
                .SortBy(x => x.Id)
                .Limit(recordsPerPage)
                .ToListAsync(cancellationToken);
        }

        public Task<List<Message>> GetExpiredMessagesAsync(TimeSpan timeSpan, CancellationToken cancellationToken = default)
        {
            var expiredAt = DateTime.UtcNow.Subtract(timeSpan);
            var filter = Builders<Message>.Filter.Lte(c => c.CreatedAt, expiredAt);
            return _context.Messages.Find(filter).ToListAsync(cancellationToken);
        }

        public Task CreateAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default)
            => _context.Messages.InsertManyAsync(messages, cancellationToken: cancellationToken);
        
        public Task DeleteAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Message>.Filter.In(c => c.Id, messages.Select(x => x.Id));
            return _context.Messages.DeleteManyAsync(filter, cancellationToken: cancellationToken);
        }
    }
}
