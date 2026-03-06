using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace UserService.Worker.Consumers.ValidateSPICreation
{
    internal class ValidateSPICreation_SPICreated_Mapper
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
