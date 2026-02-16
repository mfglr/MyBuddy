using MediatR;

namespace StudyProgramService.Application.UseCases.RequestEnrollment
{
    public record RequestEnrollmentRequest(Guid Id) : IRequest;
}
