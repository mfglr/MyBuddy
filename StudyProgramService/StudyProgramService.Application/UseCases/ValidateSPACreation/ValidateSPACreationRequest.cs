using MediatR;

namespace StudyProgramService.Application.UseCases.ValidateSPACreation
{
    public record ValidateSPACreationRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
