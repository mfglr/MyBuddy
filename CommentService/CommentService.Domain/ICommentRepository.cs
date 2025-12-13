namespace CommentService.Domain
{
    public interface ICommentRepository
    {
        Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken);
        Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Comment>> GetByRepliedIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Comment>> GetByPostIdAsync(Guid id, CancellationToken cancellationToken);

        Task CreateAsync(Comment comment, CancellationToken cancellationToken);
        Task DeleteAsync(Comment comment, CancellationToken cancellationToken);
    }
}
