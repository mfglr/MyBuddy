using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramCapacityService.Worker.MassTransit.Consumers.ReserveSPC_OnSPAApprovalValidated
{
    internal class ReserveSPC_OnSPAApprovalValidated(ISender sender, Mapper mapper) : IConsumer<SPAApprovalValidatedEvent>
    {
        public Task Consume(ConsumeContext<SPAApprovalValidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
