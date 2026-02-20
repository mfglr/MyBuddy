using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateSPTitle
{
    public record UpdateSPTitleRequest(Guid Id, string Title) : IRequest;
}
