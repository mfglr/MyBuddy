using Shared.Events.StudyProgramService.StudyProgramInvite;
using StudyProgramService.Application.UseCases.ValidateSPICreation;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateSPICreation_OnSPICreated
{
    internal class Mapper
    {
        public ValidateSPICreationRequest Map(SPICreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                @event.StudyProgramOwnerId
            );
    }
}
