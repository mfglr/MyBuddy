namespace StudyProgramCapacityService.Application.UseCases.Enroll
{
    public record EnrollRequest(Guid StudyProgramId, Guid EnrollmentRequestId) : MediatR.IRequest;
}
