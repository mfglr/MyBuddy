using MediatR;

namespace StudyProgramService.Application.UseCases.ValidateStudyApplication
{
    public record ValidateStudyApplicationRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
