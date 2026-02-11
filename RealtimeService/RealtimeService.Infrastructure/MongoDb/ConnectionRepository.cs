using MongoDB.Driver;
using RealtimeService.Domain;

namespace RealtimeService.Infrastructure.MongoDb
{
    internal class ConnectionRepository(MongoContext context) : IConnectionRepository
    {
        public Task<Connection?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            context.Connections
            .Find(Builders<Connection>.Filter.Eq(x => x.Id, id))
            .FirstOrDefaultAsync(cancellationToken);

        public Task CreateAsync(Connection connection, CancellationToken cancellationToken = default)
            => context.Connections.InsertOneAsync(connection, cancellationToken: cancellationToken);
        
        public Task UpdateAsync(Connection connection, CancellationToken cancellationToken = default) =>
            context.Connections.ReplaceOneAsync(
                Builders<Connection>.Filter.Eq(x => x.Id, connection.Id),
                connection,
                cancellationToken: cancellationToken
            );

        public Task DeleteAsync(Connection connection, CancellationToken cancellationToken = default) =>
            context.Connections.DeleteOneAsync(
                Builders<Connection>.Filter.Eq(x => x.Id, connection.Id),
                cancellationToken: cancellationToken
            );
    }
}
