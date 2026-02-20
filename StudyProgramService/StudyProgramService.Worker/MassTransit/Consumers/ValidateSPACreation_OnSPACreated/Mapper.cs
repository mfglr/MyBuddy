using Shared.Events.StudyProgramService;
using StudyProgramService.Application.UseCases.ValidateSPACreation;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateSPACreation_OnSPACreated
{
    internal class Mapper
    {
        public ValidateSPACreationRequest Map(SPACreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
