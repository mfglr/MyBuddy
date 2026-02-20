namespace StudyProgramCapacityService.Application.UseCases.ReserveSPC
{
    public record ReserveSPCRequest(Guid StudyProgramId, Guid UserId) : MediatR.IRequest;
}
