using MediatR;

namespace StudyProgramService.Application.UseCases.ApproveRequestEnrollment
{
    public record ApproveRequestEnrollmentRequest(Guid Id) : IRequest;
}
