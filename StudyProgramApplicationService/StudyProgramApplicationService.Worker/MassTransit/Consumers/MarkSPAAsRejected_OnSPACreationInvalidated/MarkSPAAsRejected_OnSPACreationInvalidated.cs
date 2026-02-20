using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPACreationInvalidated
{
    internal class MarkSPAAsRejected_OnSPACreationInvalidated(
        Mapper mapper,
        ISender sender
    ) : IConsumer<SPACreationInvalidatedEvent>
    {
        public Task Consume(ConsumeContext<SPACreationInvalidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message));
    }
}
