using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace UserService.Worker.Consumers.ValidateSPICreation
{
    internal class ValidateSPICreationMapper
    {
        public SPICreationInvalidatedEvent MapInvalidatedEvent(SPICreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                SPIInvalidationReason.UserNotFound
            );
        public SPICreationValidatedEvent MapValidatedEvent(SPICreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
