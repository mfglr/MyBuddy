using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramCapacityService.Worker.MassTransit.Consumers.ReserveSPC_OnSPACreationValidated
{
    internal class ReserveSPC_OnSPACreationValidated(
        Mapper mapper,
        ISender sender
    )
        : IConsumer<SPACreationValidatedEvent>
    {
        public async Task Consume(ConsumeContext<SPACreationValidatedEvent> context)
        {
            if (context.Message.EnrollmentStrategy == EnrollmentStrategy.Open)
                await sender.Send(mapper.Map(context.Message), context.CancellationToken);
        }
    }
}
