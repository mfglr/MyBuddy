using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace StudyProgramInviteService.Worker.MassTransit.Consumers.InvalidateSPICreation_OnSPICreationInvalidated
{
    internal class InvalidateSPICreation_OnSPICreationInvalidated(ISender sender, Mapper mapper) : IConsumer<SPICreationInvalidatedEvent>
    {
        public Task Consume(ConsumeContext<SPICreationInvalidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
