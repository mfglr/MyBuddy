using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramApplication;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateStudyApplication_OnStudyApplicationCreated
{
    internal class ValidateStudyApplication_OnStudyApplicationCreated_StudyProgramService(ValidateStudyApplication_OnStudyApplicationCreated_Mapper mapper, ISender sender) : IConsumer<StudyProgramApplicationCreatedEvent>
    {
        public Task Consume(ConsumeContext<StudyProgramApplicationCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
