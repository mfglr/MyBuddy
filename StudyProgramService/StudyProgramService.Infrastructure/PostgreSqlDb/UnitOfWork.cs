using StudyProgramService.Application;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal class UnitOfWork(PostgreSqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) =>
            context.SaveChangesAsync(cancellationToken);
    }
}
