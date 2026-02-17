using EnrollmentRequestService.Application.UseCases.RejectEnrollmentRequest;
using EnrollmentRequestService.Domain;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace EnrollmentRequestService.Worker.MassTransit.Consumers.MarkAsRejected_OnStudyProgramValidationFailed
{
    internal class MarkAsRejected_OnStudyProgramValidationFailed_Mapper
    {
        public RejectEnrollmentRequest_Request Map(StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event @event) =>
            new(
                @event.StudyPromamId,
                @event.UserId,
                (Domain.EnrollmentRequestRejectionReason)@event.Reason
            );
    }
}
