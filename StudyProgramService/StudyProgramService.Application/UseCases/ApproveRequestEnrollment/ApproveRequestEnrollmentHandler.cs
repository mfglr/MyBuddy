using MediatR;

namespace StudyProgramService.Application.UseCases.ApproveRequestEnrollment
{
    internal class ApproveRequestEnrollmentHandler(IUnitOfWork unitOfWork) : IRequestHandler<ApproveRequestEnrollmentRequest>
    {
        public Task Handle(ApproveRequestEnrollmentRequest request, CancellationToken cancellationToken)
        {
        }
    }
}
