using MediaService.Application;
using MediaService.Infrastructure.PostgreSql;

namespace MediaService.Infrastructure.PostgreSql
{
    internal class UnitOfWork(SqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) =>
            context.SaveChangesAsync(cancellationToken);
    }
}
