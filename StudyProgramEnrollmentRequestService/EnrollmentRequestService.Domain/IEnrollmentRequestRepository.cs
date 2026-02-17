namespace EnrollmentRequestService.Domain
{
    public interface IEnrollmentRequestRepository
    {
        Task<EnrollmentRequest?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(EnrollmentRequest enrollmentRequest, CancellationToken cancellationToken);
    }
}
