namespace StudyProgramCapacityService.Application.UseCases.UpdateCapacity
{
    public record UpdateCapacityRequest(Guid StudyProgramId,int Capacity) : MediatR.IRequest;
}
