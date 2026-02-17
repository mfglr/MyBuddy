using EnrollmentRequestService.Domain;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace EnrollmentRequestService.Application.UseCases.MarkAsValidatedByStudyProgram
{
    internal class MarkAsValidatedByStudyProgramMapper
    {
        public EnrollmentRequestValidatedEvent Map(EnrollmentRequest enrollmentRequest) =>
            new(
                enrollmentRequest.StudyProgramId,
                enrollmentRequest.UserId,
                enrollmentRequest.CreatedAt,
                enrollmentRequest.UpdatedAt,
                enrollmentRequest.Version,
                enrollmentRequest.Status.Value,
                (Shared.Events.StudyProgramService.EnrollmentRequest.StudyProgramEnrollmentRequest_RejectionReason?)enrollmentRequest.RejectionReason,
                enrollmentRequest.IsValidatedByStudyProgram
            );
    }
}
