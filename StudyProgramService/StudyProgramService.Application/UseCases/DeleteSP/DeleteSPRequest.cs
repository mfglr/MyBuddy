using MediatR;

namespace StudyProgramService.Application.UseCases.DeleteSP
{
    public record DeleteSPRequest(Guid Id) : IRequest;
}
