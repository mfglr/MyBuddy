using EnrollmentRequestService.Domain;
using MediatR;

namespace EnrollmentRequestService.Application.UseCases.RejectEnrollmentRequest
{
    internal class RejectEnrollmentRequestHandler(WorkerIdProvider workerIdProvider, IIdentityService identityService, IEnrollmentRequestRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<RejectEnrollmentRequest_Request>
    {
        public async Task Handle(RejectEnrollmentRequest_Request request, CancellationToken cancellationToken)
        {
            var enrollmenRequest = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            
            if (enrollmenRequest == null || enrollmenRequest.IsDeleted)
                throw new EnrollmentRequestNotFoundException();
            
            if(enrollmenRequest.StudyProgramOwnerId != identityService.UserId)
                workerIdProvider.Validate(identityService.UserId);
            
            enrollmenRequest.Reject(request.Reason);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
