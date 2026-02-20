using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramCapacityService.Worker.MassTransit.Consumers.CreateSPC_OnSPCreated
{
    internal class CreateSPC_OnSPCreated(Mapper mapper, ISender sender) : IConsumer<SPCreatedEvent>
    {
        public Task Consume(ConsumeContext<SPCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
