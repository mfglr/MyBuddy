using EnrollmentRequestService.Domain;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace EnrollmentRequestService.Application.UseCases.CreateEnrollmentRequest
{
    internal class CreateEnrollmentRequestMapper
    {
        public StudyProgramEnrollmentRequest_Created_Event Map(EnrollmentRequest enrollmentRequest) =>
            new(
                enrollmentRequest.StudyProgramId,
                enrollmentRequest.UserId,
                enrollmentRequest.CreatedAt,
                enrollmentRequest.UpdatedAt,
                enrollmentRequest.Version,
                enrollmentRequest.Status.Value,
                (StudyProgramEnrollmentRequest_RejectionReason?)enrollmentRequest.RejectionReason,
                enrollmentRequest.IsValidatedByStudyProgram
            );
    }
}
