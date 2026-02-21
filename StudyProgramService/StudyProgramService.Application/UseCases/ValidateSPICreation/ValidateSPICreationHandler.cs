using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramInvite;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.ValidateSPICreation
{
    internal class ValidateSPICreationHandler(ISPRepository spRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<ValidateSPICreationRequest>
    {
        public async Task Handle(ValidateSPICreationRequest request, CancellationToken cancellationToken)
        {
            var sp = await spRepository.GetByIdAsync(request.StudyProgramId, cancellationToken);
            if(sp == null || sp.IsDeleted)
            {
                var invalidEvent = new SPICreationInvalidatedEvent(request.StudyProgramId, request.UserId, SPIInvalidationReason.SPNotFound);
                await publishEndpoint.Publish(invalidEvent, cancellationToken);
                return;
            }
            if(sp.UserId != request.StudyProgramOwnerId)
            {
                var invalidEvent = new SPICreationInvalidatedEvent(request.StudyProgramId, request.UserId, SPIInvalidationReason.NotSPOwner);
                await publishEndpoint.Publish(invalidEvent, cancellationToken);
                return;
            }
            if(sp.Status != SPStatus.Active)
            {
                var invalidEvent = new SPICreationInvalidatedEvent(request.StudyProgramId, request.UserId, SPIInvalidationReason.InactiveSP);
                await publishEndpoint.Publish(invalidEvent, cancellationToken);
                return;
            }
            var validEvent = new SPICreationValidatedEvent(request.StudyProgramId, request.UserId);
            await publishEndpoint.Publish(validEvent, cancellationToken);
        }
    }
}
