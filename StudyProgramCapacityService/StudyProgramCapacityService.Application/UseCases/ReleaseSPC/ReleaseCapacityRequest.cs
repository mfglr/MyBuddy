namespace StudyProgramCapacityService.Application.UseCases.ReleaseSPC
{
    public record ReleaseCapacityRequest(Guid StudyProgramId) : MediatR.IRequest;
}
