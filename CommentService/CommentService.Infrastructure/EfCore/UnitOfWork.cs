using CommentService.Application;

namespace CommentService.Infrastructure.EfCore
{
    internal class UnitOfWork(EfCoreMongoContext context) : IUnitOfWork
    {
        private readonly EfCoreMongoContext _context = context;

        public Task CommitAsync(CancellationToken cancellationToken) =>
            _context.SaveChangesAsync(cancellationToken);
    }
}
