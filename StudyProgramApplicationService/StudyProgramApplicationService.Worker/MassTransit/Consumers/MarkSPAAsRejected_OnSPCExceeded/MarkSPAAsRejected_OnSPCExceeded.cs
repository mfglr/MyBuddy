using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPCExceeded
{
    internal class MarkSPAAsRejected_OnSPCExceeded(
        ISender sender,
        Mapper mapper
    ) : IConsumer<SPCExceededEvent>
    {
        public Task Consume(ConsumeContext<SPCExceededEvent> context) =>
            sender.Send(mapper.Map(context.Message));
    }
}
