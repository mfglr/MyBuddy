using Shared.Events.StudyProgramService;

namespace StudyProgramService.Application.UseCases.ValidateSPACreation
{
    internal class ValidateSPACreationMapper
    {
        public SPACreationValidatedEvent MapValidatedEvent(
            ValidateSPACreationRequest request,
            string enrollmentStrategy
        ) =>
            new(
                request.StudyProgramId,
                request.UserId,
                enrollmentStrategy
            );

        public SPACreationInvalidatedEvent MapInvalidatedEvent(
            ValidateSPACreationRequest request,
            SPARejectionReason reason
        ) =>
            new(
                request.StudyProgramId,
                request.UserId,
                reason
            );
    }
}
