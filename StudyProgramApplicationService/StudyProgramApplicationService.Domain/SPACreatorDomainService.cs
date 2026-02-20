namespace StudyProgramApplicationService.Domain
{
    public class SPACreatorDomainService(ISPARepository repository)
    {
        public async Task<SPA> CreateAsync(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId, CancellationToken cancellationToken)
        {
            var enrollmentRequest = await repository.GetAsync(studyProgramId, userId, cancellationToken);
            
            if(enrollmentRequest != null && !enrollmentRequest.IsDeleted)    
                throw new DuplicateSPAException();
            
            if(enrollmentRequest != null && enrollmentRequest.IsDeleted)
            {
                enrollmentRequest.Restore();
                return enrollmentRequest;
            }

            enrollmentRequest = new SPA(studyProgramId, userId, studyProgramOwnerId);
            enrollmentRequest.Create();

            return enrollmentRequest;
        }
    }
}
