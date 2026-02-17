using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace EnrollmentRequestService.Worker.MassTransit.Consumers.MarkAsValidated_OnStudyProgramValidationSuccess
{
    internal class MarkAsValidated_OnStudyProgramValidationSuccess_EnrollmentRequestService(MarkAsValidated_OnStudyProgramValidationSuccess_Mapper mapper,ISender sender) : IConsumer<StudyProgramEnrollmentRequest_ValidationSuccessByStudyProgram_Event>
    {
        public Task Consume(ConsumeContext<StudyProgramEnrollmentRequest_ValidationSuccessByStudyProgram_Event> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
