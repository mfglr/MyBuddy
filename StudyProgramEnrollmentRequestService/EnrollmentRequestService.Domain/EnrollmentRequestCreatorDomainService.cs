namespace EnrollmentRequestService.Domain
{
    public class EnrollmentRequestCreatorDomainService(IEnrollmentRequestRepository repository)
    {
        public async Task<EnrollmentRequest> CreateAsync(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId, CancellationToken cancellationToken)
        {
            var enrollmentRequest = await repository.GetAsync(studyProgramId, userId, cancellationToken);
            
            if(enrollmentRequest != null && !enrollmentRequest.IsDeleted)    
                throw new DuplicateEnrollmentRequestException();
            
            if(enrollmentRequest != null && enrollmentRequest.IsDeleted)
            {
                enrollmentRequest.Restore();
                return enrollmentRequest;
            }

            enrollmentRequest = new EnrollmentRequest(studyProgramId, userId, studyProgramOwnerId);
            enrollmentRequest.Create();

            return enrollmentRequest;
        }
    }
}
