namespace PostService.Application
{
    public interface IUnitOfWork
    {
        Task CreateTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task AbortTransactionAsync(CancellationToken cancellationToken);
    }
}
