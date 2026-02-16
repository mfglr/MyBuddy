using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.EnrollmentRequestAggregate.Entities;

namespace StudyProgramService.Application.UseCases.RequestEnrollment
{
    internal class RequestEnrollmentMapper
    {
        public EnrollmentRequestCreatedEvent Map(EnrollmentRequest enrollmentRequest) =>
            new(
                enrollmentRequest.StudyProgramId,
                enrollmentRequest.UserId,
                enrollmentRequest.CreatedAt,
                enrollmentRequest.UpdatedAt,
                enrollmentRequest.Version,
                enrollmentRequest.Status.Value
            );
    }
}
