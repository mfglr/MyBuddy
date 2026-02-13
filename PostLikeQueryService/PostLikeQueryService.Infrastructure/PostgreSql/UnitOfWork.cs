using PostLikeQueryService.Application;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class UnitOfWork(SqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken = default) =>
            context.SaveChangesAsync(cancellationToken);
    }
}
