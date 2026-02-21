using MediatR;
using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace StudyProgramInviteService.Application.UseCases.InvalidateSPICreation
{
    public record InvalidateSPICreationRequest(Guid StudyProgramId, Guid UserId, SPIInvalidationReason InvalidationReason) : IRequest;
}
