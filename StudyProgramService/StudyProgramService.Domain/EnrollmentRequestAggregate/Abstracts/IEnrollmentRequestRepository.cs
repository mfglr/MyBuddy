using StudyProgramService.Domain.EnrollmentRequestAggregate.Entities;

namespace StudyProgramService.Domain.EnrollmentRequestAggregate.Abstracts
{
    public interface IEnrollmentRequestRepository
    {
        Task<bool> ExistAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(EnrollmentRequest enrollmentRequest, CancellationToken cancellationToken);
    }
}
