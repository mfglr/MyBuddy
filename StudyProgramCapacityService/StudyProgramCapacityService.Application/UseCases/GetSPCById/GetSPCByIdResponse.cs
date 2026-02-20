namespace StudyProgramCapacityService.Application.UseCases.GetSPCById
{
    public record GetSPCByIdResponse(
        Guid StudyProgramId,
        int Capacity,
        int EnrollmentCount
    );
}
