using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateDescription
{
    public record UpdateDescriptionRequest(Guid Id, string Description) : IRequest;
}
