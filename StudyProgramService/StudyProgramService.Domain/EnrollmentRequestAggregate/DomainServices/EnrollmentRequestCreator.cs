using StudyProgramService.Domain.EnrollmentRequestAggregate.Abstracts;
using StudyProgramService.Domain.EnrollmentRequestAggregate.Entities;
using StudyProgramService.Domain.EnrollmentRequestAggregate.Exceptions;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Domain.EnrollmentRequestAggregate.DomainServices
{
    public class EnrollmentRequestCreator(IStudyProgramRepository programRepository, IEnrollmentRequestRepository enrollmentRequestRepository)
    {
        public async Task CreateAsync(EnrollmentRequest enrollmentRequest, CancellationToken cancellationToken)
        {
            var studyProgram =
                await programRepository.GetByIdAsync(enrollmentRequest.StudyProgramId, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (!studyProgram.IsFree)
                throw new EnrollmentNotAllowedForPaidProgramException();

            enrollmentRequest.Create();
        }
    }
}
