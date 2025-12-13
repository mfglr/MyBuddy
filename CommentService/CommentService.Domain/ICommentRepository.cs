namespace CommentService.Domain
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetByRepliedIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Comment comment, CancellationToken cancellationToken);
        Task UpdateAsync(Comment comment, CancellationToken cancellationToken);
        Task UpdateAsync(List<Comment> comment, CancellationToken cancellationToken);
        Task DeleteAsync(Comment comment, CancellationToken cancellationToken);
        Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken);
    }
}
