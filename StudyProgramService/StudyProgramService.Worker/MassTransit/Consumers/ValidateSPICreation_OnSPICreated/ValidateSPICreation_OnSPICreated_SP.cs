using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateSPICreation_OnSPICreated
{
    internal class ValidateSPICreation_OnSPICreated_SP(ISender sender, Mapper mapper) : IConsumer<SPICreatedEvent>
    {
        public Task Consume(ConsumeContext<SPICreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
