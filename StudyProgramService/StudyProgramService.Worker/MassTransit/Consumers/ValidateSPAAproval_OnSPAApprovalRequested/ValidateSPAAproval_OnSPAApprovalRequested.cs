using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateSPAAproval_OnSPAApprovalRequested
{
    internal class ValidateSPAAproval_OnSPAApprovalRequested(
        ISender sender,
        Mapper mapper
    ) : IConsumer<SPAApprovalRequestedEvent>
    {
        public Task Consume(ConsumeContext<SPAApprovalRequestedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
