using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramApplication;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkAsValidated_OnValidationSuccessByStudyProgram
{
    internal class MarkAsValidated_OnValidationSuccessByStudyProgram_StudyProgramApplicationService(MarkAsValidated_OnValidationSuccessByStudyProgram_Mapper mapper,ISender sender) : IConsumer<StudyProgramApplicationValidationSuccessEvent_StudyProgramService>
    {
        public Task Consume(ConsumeContext<StudyProgramApplicationValidationSuccessEvent_StudyProgramService> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
