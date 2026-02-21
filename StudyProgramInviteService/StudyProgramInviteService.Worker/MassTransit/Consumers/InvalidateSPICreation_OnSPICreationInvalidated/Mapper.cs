using Shared.Events.StudyProgramService.StudyProgramInvite;
using StudyProgramInviteService.Application.UseCases.InvalidateSPICreation;

namespace StudyProgramInviteService.Worker.MassTransit.Consumers.InvalidateSPICreation_OnSPICreationInvalidated
{
    internal class Mapper
    {
        public InvalidateSPICreationRequest Map(SPICreationInvalidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                @event.Reason
            );
    }
}
