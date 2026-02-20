using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsApproved_OnSPCReserved
{
    internal class MarkSPAAsApproved_OnSPCReserved(ISender sender,Mapper mapper) : IConsumer<SPCReservedEvent>
    {
        public Task Consume(ConsumeContext<SPCReservedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
