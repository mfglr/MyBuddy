using MediatR;

namespace StudyProgramService.Application.UseCases.DeleteStudyProgram
{
    public record DeleteStudyProgramRequest(Guid Id) : IRequest;
}
