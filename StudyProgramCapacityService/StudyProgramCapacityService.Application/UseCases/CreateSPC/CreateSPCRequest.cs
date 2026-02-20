namespace StudyProgramCapacityService.Application.UseCases.CreateCapacity
{
    public record CreateSPCRequest(Guid StudyProgramId, Guid StudyProgramOwnerId, int Capacity) : MediatR.IRequest;
}
