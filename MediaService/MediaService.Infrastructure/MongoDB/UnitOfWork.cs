using MassTransit.MongoDbIntegration;
using MediaService.Application;

namespace MediaService.Infrastructure.MongoDB
{
    internal class UnitOfWork(MongoDbContext context) : IUnitOfWork
    {
        public Task CreateTransactionAsync(CancellationToken cancellationToken) =>
            context.BeginTransaction(cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken) =>
            context.CommitTransaction(cancellationToken);
    }
}
