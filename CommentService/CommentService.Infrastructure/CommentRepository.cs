using CommentService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Infrastructure
{
    internal class CommentRepository(MongoContext context) : ICommentRepository
    {
        private readonly MongoContext _context = context;

        public Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken) =>
            _context.Comments.AnyAsync(x => x.Id == id, cancellationToken);
        
        public Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
           _context.Comments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        public Task<List<Comment>> GetByRepliedIdAsync(Guid id, CancellationToken cancellationToken) =>
            _context.Comments.Where(x => x.RepliedId == id).ToListAsync(cancellationToken);

        public Task<List<Comment>> GetByPostIdAsync(Guid id, CancellationToken cancellationToken) =>
            _context.Comments.Where(x => x.PostId == id && x.ParentId == null).ToListAsync(cancellationToken);

        public async Task CreateAsync(Comment comment, CancellationToken cancellationToken) =>
            await _context.Comments.AddAsync(comment, cancellationToken);

        public Task DeleteAsync(Comment comment, CancellationToken cancellationToken) =>
            Task.FromResult(_context.Remove(comment));
    }
}
