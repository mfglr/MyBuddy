using PostQueryService.Application;

namespace PostQueryService.Infrastructure.MsSql
{
    internal class UnitOfWork(MsSqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) =>
            context.SaveChangesAsync(cancellationToken);
    }
}