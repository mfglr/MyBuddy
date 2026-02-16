namespace StudyProgramService.Application
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
