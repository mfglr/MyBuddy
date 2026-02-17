using StudyProgramApplicationService.Application;

namespace StudyProgramApplicationService.Infrastructure.PostgreSqlDb
{
    internal class UnitOfWork(PostgreSqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) =>
            context.SaveChangesAsync(cancellationToken);
    }
}
