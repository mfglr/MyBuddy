using EnrollmentRequestService.Application;

namespace EnrollmentRequestService.Infrastructure.PostgreSqlDb
{
    internal class UnitOfWork(PostgreSqlContext context) : IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken) =>
            context.SaveChangesAsync(cancellationToken);
    }
}
