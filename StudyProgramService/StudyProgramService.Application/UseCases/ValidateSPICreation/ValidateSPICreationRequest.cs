using MediatR;

namespace StudyProgramService.Application.UseCases.ValidateSPICreation
{
    public record ValidateSPICreationRequest(Guid StudyProgramId, Guid UserId, Guid StudyProgramOwnerId) : IRequest;
}
