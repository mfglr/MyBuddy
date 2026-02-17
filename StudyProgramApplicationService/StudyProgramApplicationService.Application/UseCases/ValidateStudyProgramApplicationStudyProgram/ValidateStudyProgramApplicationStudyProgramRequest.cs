using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.ValidateStudyProgramApplicationStudyProgram
{
    public record ValidateStudyProgramApplicationStudyProgramRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
