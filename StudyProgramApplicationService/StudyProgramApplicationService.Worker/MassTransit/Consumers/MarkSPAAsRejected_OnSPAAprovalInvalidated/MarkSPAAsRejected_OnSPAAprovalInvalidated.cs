using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPAAprovalInvalidated
{
    internal class MarkSPAAsRejected_OnSPAAprovalInvalidated(ISender sender,Mapper mapper) : IConsumer<SPAApprovalInvalidatedEvent>
    {
        public Task Consume(ConsumeContext<SPAApprovalInvalidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
