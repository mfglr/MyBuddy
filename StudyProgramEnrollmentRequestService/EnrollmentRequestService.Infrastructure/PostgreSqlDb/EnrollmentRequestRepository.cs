using EnrollmentRequestService.Domain;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentRequestService.Infrastructure.PostgreSqlDb
{
    internal class EnrollmentRequestRepository(PostgreSqlContext context) : IEnrollmentRequestRepository
    {
        public async Task CreateAsync(EnrollmentRequest enrollmentRequest, CancellationToken cancellationToken) =>
            await context.EnrollmentRequests.AddAsync(enrollmentRequest, cancellationToken);

        public Task<EnrollmentRequest?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken) =>
            context.EnrollmentRequests.FirstOrDefaultAsync(x => x.StudyProgramId == studyProgramId && x.UserId == userId, cancellationToken);
    }
}
