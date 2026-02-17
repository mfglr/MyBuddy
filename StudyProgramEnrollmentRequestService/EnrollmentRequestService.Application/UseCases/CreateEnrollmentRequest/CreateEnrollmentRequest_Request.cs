using MediatR;

namespace EnrollmentRequestService.Application.UseCases.CreateEnrollmentRequest
{
    public record CreateEnrollmentRequest_Request(Guid StudyProgramId, Guid StudyProgramOwnerId) : IRequest;
}
