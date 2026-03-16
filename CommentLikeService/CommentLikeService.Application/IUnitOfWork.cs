namespace CommentLikeService.Application
{
    public interface IUnitOfWork
    {
        Task CreateTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
    }
}
