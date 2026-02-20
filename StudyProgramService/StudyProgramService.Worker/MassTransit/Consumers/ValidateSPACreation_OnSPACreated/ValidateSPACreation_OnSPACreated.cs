using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateSPACreation_OnSPACreated
{
    internal class ValidateSPACreation_OnSPACreated(Mapper mapper, ISender sender) : IConsumer<SPACreatedEvent>
    {
        public Task Consume(ConsumeContext<SPACreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
