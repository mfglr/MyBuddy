using MediatR;

namespace StudyProgramInviteService.Application.UseCases.ValidateSPICreation
{
    public record ValidateSPICreationRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
