using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramApplication;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkAsRejected_OnValidationFailedStudyProgram
{
    internal class MarkAsRejected_OnStudyProgramValidationFailed_EnrrollmentRequestService(MarkAsRejected_OnStudyProgramValidationFailed_Mapper mapper,ISender sender) : IConsumer<StudyProgramApplicationValidationFailedEvent_StudyProgramService>
    {
        public Task Consume(ConsumeContext<StudyProgramApplicationValidationFailedEvent_StudyProgramService> context) =>
            sender.Send(mapper.Map(context.Message));
    }
}
