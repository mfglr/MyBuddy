using Shared.Events.StudyProgramService.EnrollmentRequest;
using StudyProgramService.Application.UseCases.ValidateEnrollmentRequest;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateEnrollmentRequest_OnEnrollmentRequestCreated
{
    internal class ValidateEnrollmentRequest_OnEnrollmentRequestCreated_Mapper
    {
        public ValidateEnrollmentRequest_Request Map(StudyProgramEnrollmentRequest_Created_Event @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
