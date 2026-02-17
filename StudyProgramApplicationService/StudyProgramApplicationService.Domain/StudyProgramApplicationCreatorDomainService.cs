namespace StudyProgramApplicationService.Domain
{
    public class StudyProgramApplicationCreatorDomainService(IStudyProgramApplicationRepository repository)
    {
        public async Task<StudyProgramApplication> CreateAsync(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId, CancellationToken cancellationToken)
        {
            var enrollmentRequest = await repository.GetAsync(studyProgramId, userId, cancellationToken);
            
            if(enrollmentRequest != null && !enrollmentRequest.IsDeleted)    
                throw new DuplicateStudyProgramApplicationException();
            
            if(enrollmentRequest != null && enrollmentRequest.IsDeleted)
            {
                enrollmentRequest.Restore();
                return enrollmentRequest;
            }

            enrollmentRequest = new StudyProgramApplication(studyProgramId, userId, studyProgramOwnerId);
            enrollmentRequest.Create();

            return enrollmentRequest;
        }
    }
}
