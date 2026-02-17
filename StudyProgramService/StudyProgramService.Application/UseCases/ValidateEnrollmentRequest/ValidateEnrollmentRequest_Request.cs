using MediatR;

namespace StudyProgramService.Application.UseCases.ValidateEnrollmentRequest
{
    public record ValidateEnrollmentRequest_Request(Guid StudyProgramId, Guid UserId) : IRequest;
}
