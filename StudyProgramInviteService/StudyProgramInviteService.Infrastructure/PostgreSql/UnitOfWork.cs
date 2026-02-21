using StudyProgramInviteService.Application;

namespace StudyProgramInviteService.Infrastructure.PostgreSql
{
    internal class UnitOfWork(SqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) =>
            context.SaveChangesAsync(cancellationToken);
    }
}
