using CommentLikeService.Application;
using MassTransit.MongoDbIntegration;

namespace CommentLikeService.Infrastructure.MongoDb
{
    internal class UnitOfWork(MongoDbContext context) : IUnitOfWork
    {
        public Task CreateTransactionAsync(CancellationToken cancellationToken) =>
            context.BeginTransaction(cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken) =>
            context.CommitTransaction(cancellationToken);
    }
}
