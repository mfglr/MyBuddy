using MediatR;

namespace StudyProgramService.Application.UseCases.IncreaseCapacity
{
    public record IncreaseCapacityRequest(Guid Id, int Increment) : IRequest;
}
