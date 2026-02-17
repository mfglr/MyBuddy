using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace EnrollmentRequestService.Worker.MassTransit.Consumers.MarkAsRejected_OnStudyProgramValidationFailed
{
    internal class MarkAsRejected_OnStudyProgramValidationFailed_EnrrollmentRequestService(MarkAsRejected_OnStudyProgramValidationFailed_Mapper mapper,ISender sender) : IConsumer<StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event>
    {
        public Task Consume(ConsumeContext<StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event> context) =>
            sender.Send(mapper.Map(context.Message));
    }
}
