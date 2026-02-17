using EnrollmentRequestService.Domain;
using MediatR;

namespace EnrollmentRequestService.Application.UseCases.RejectEnrollmentRequest
{
    public record RejectEnrollmentRequest_Request(Guid StudyProgramId, Guid UserId, EnrollmentRequestRejectionReason Reason) : IRequest;
}
