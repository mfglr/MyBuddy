using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateCapacity
{
    public record UpdateCapacityRequest(Guid Id, int Capacity) : IRequest;
}
