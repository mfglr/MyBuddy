namespace CommentService.Domain
{
    public interface ICommentRepository
    {
        Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken);
        Task<Comment?> GetCommentByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Comment>> GetCommentsByRepliedIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Comment>> GetCommentsByPostIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Comment comment, CancellationToken cancellationToken);
        Task UpdateAsync(Comment comment, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<Comment> comments, CancellationToken cancellationToken);
        Task DeleteAsync(Comment comment, CancellationToken cancellationToken);
    }
}
