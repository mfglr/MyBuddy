using Shared.Events.StudyProgramService.StudyProgramInvite;
using StudyProgramInviteService.Application.UseCases.ValidateSPICreation;

namespace StudyProgramInviteService.Worker.MassTransit.Consumers.ValidateSPICreation_OnSPICreationValidated
{
    internal class Mapper
    {
        public ValidateSPICreationRequest Map(SPICreationValidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
