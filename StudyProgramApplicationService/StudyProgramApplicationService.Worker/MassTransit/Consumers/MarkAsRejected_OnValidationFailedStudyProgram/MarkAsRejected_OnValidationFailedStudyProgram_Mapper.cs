using Shared.Events.StudyProgramService.StudyProgramApplication;
using StudyProgramApplicationService.Application.UseCases.RejectStudyProgramApplication;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkAsRejected_OnValidationFailedStudyProgram
{
    internal class MarkAsRejected_OnStudyProgramValidationFailed_Mapper
    {
        public RejectStudyProgramApplicationRequest  Map(StudyProgramApplicationValidationFailedEvent_StudyProgramService @event) =>
            new(
                @event.StudyPromamId,
                @event.UserId,
                (Domain.StudyProgramApplicationRejectionReason)@event.Reason
            );
    }
}
