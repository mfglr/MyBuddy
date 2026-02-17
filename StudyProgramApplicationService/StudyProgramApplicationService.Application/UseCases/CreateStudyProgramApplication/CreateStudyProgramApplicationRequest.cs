using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.CreateStudyProgramApplication
{
    public record CreateStudyProgramApplicationRequest(Guid StudyProgramId, Guid StudyProgramOwnerId) : IRequest;
}
