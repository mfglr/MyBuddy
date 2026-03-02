using PostService.Application;

namespace PostService.Infrastructure.PostgreSql
{
    internal class UnitOfWork(SqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) => context.SaveChangesAsync(cancellationToken);
    }
}
