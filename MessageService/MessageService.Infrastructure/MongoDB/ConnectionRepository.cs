using MessageService.Domain.ConnectionAggregate;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDB
{
    internal class ConnectionRepository(MongoContext context) : IConnectionRepository
    {
        public Task CreateAsync(Connection connection, CancellationToken cancellationToken) =>
            context.Connections.InsertOneAsync(connection, cancellationToken: cancellationToken);
        public Task DeleteAsync(Connection connection, CancellationToken cancellationToken)
        {
            var filter = Builders<Connection>.Filter.Eq(x => x.Id,connection.Id);
            return context.Connections.DeleteOneAsync(filter, cancellationToken: cancellationToken);
        }
        public async Task<Connection?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Connection>.Filter.Eq(x => x.Id, id);
            var document = await context.Connections.FindAsync(filter, cancellationToken: cancellationToken);
            return await document.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
        public async Task UpdateAsync(Connection connection, CancellationToken cancellationToken)
        {
            var filter = Builders<Connection>.Filter.And(
                Builders<Connection>.Filter.Eq(x => x.Id, connection.Id),
                Builders<Connection>.Filter.Eq(x => x.Version, connection.Version - 1)
            );
            var response = await context.Connections.ReplaceOneAsync(filter, connection, cancellationToken: cancellationToken);
            if (response.ModifiedCount < 1)
                throw new AppConcurencyException();
        }
    }
}
