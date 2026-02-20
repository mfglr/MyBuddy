using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.RequestSPAApproval
{
    internal class RequestSPAApprovalHandler(
        RequestSPAApprovalMapper mapper,
        IPublishEndpoint publishEndpoint,
        IIdentityService identityService,
        ISPARepository repository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<RequestSPAApprovalRequest>
    {
        public async Task Handle(RequestSPAApprovalRequest request, CancellationToken cancellationToken)
        {
            var application = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (application == null || application.IsDeleted)
                throw new SPANotFoundException();

            if (application.StudyProgramOwnerId != identityService.UserId)
                throw new AuthorizationException();

            application.MarkAsUnderApprovalValidation();
            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(application);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
