using CommentService.Application;

namespace CommentService.Infrastructure
{
    internal class UnitOfWork(MongoContext context) : IUnitOfWork
    {
        private readonly MongoContext _context = context;

        public Task CommitAsync(CancellationToken cancellationToken) =>
            _context.SaveChangesAsync(cancellationToken);
    }
}
