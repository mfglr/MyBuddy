using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.RejectStudyProgramApplication
{
    internal class RejectStudyProgramApplicationHandler(WorkerIdProvider workerIdProvider, IIdentityService identityService, IStudyProgramApplicationRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<RejectStudyProgramApplicationRequest>
    {
        public async Task Handle(RejectStudyProgramApplicationRequest request, CancellationToken cancellationToken)
        {
            var enrollmenRequest = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (enrollmenRequest == null || enrollmenRequest.IsDeleted)
                throw new StudyProgramApplicationNotFoundException();
            
            if(enrollmenRequest.StudyProgramOwnerId != identityService.UserId)
                workerIdProvider.Validate(identityService.UserId);
            
            enrollmenRequest.Reject(request.Reason);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
