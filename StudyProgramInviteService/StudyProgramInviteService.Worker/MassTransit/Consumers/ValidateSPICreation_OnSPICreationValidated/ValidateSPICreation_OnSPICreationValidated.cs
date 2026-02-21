using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace StudyProgramInviteService.Worker.MassTransit.Consumers.ValidateSPICreation_OnSPICreationValidated
{
    internal class ValidateSPICreation_OnSPICreationValidated(ISender sender, Mapper mapper) : IConsumer<SPICreationValidatedEvent>
    {
        public Task Consume(ConsumeContext<SPICreationValidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
