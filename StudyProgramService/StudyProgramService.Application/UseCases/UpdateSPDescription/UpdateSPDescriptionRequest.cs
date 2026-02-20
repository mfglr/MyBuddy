using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateSPDescription
{
    public record UpdateSPDescriptionRequest(Guid Id, string Description) : IRequest;
}
