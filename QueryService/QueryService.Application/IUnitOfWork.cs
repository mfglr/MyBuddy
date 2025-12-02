namespace QueryService.Application
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
