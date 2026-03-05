using MassTransit.MongoDbIntegration;
using UserService.Application;

namespace UserService.Infrastructure.MongoDB
{
    internal class UnitOfWork(MongoDbContext context) : IUnitOfWork
    {
        public Task CreateTransactionAsync(CancellationToken cancellationToken) =>
            context.BeginTransaction(cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken) =>
            context.CommitTransaction(cancellationToken);
    }
}
