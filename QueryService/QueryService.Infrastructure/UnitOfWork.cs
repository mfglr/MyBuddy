using QueryService.Application;

namespace QueryService.Infrastructure
{
    internal class UnitOfWork(SqlContext context) : IUnitOfWork
    {
        private readonly SqlContext _context = context;

        public Task CommitAsync(CancellationToken cancellationToken) =>
            _context.SaveChangesAsync(cancellationToken);
    }
}
