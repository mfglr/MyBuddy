using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateTitle
{
    public record UpdateTitleRequest(Guid Id, string Title) : IRequest;
}
