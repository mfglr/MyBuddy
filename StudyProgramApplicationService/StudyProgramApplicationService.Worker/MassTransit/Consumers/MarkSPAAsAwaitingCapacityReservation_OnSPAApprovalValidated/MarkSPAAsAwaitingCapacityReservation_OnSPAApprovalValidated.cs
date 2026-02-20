using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsAwaitingCapacityReservation_OnSPAApprovalValidated
{
    internal class MarkSPAAsAwaitingCapacityReservation_OnSPAApprovalValidated(ISender sender, Mapper mapper) : IConsumer<SPAApprovalValidatedEvent>
    {
        public Task Consume(ConsumeContext<SPAApprovalValidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
