using Shared.Events.StudyProgramService;

namespace StudyProgramCapacityService.Application.UseCases.Enroll
{
    internal class EnrollMapper
    {
        public StudyProgramEnrollmentSuccessEventEvent Map(Guid enrollmentRequestId) =>
            new(
                enrollmentRequestId
            );

        public StudyProgramEnrollmentFailedEvent MapToFailedEvent(Guid enrollmentRequestId) =>
            new(
                enrollmentRequestId,
                "insufficient-capacity"
            );
    }
}
