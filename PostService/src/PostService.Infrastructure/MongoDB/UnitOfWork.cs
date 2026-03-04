using MassTransit.MongoDbIntegration;
using PostService.Application;

namespace PostService.Infrastructure.MongoDB
{
    internal class UnitOfWork(MongoDbContext context) : IUnitOfWork
    {
        public Task CreateTransactionAsync(CancellationToken cancellationToken) =>
            context.BeginTransaction(cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken) =>
            context.CommitTransaction(cancellationToken);
    }
}
