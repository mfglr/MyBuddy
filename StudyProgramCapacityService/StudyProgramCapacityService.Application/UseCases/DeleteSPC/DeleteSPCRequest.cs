namespace StudyProgramCapacityService.Application.UseCases.DeleteSPC
{
    public record DeleteSPCRequest(Guid Id) : MediatR.IRequest;
}
