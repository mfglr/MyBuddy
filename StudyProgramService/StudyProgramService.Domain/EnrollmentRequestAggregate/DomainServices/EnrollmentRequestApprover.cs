using StudyProgramService.Domain.EnrollmentRequestAggregate.Entities;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Domain.EnrollmentRequestAggregate.DomainServices
{
    public class EnrollmentRequestApprover(IStudyProgramRepository programRepository)
    {
        public async Task ApproveAsync(EnrollmentRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = 
                await programRepository.GetByIdAsync(request.StudyProgramId, cancellationToken) ??
                throw new StudyProgramNotFoundException();
            
            studyProgram.IncreaseEnrollmentCount();
            request.Approve();
        }
    }
}
