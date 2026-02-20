using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected
{
    internal class MarkSPAAsRejectedHandler(
        WorkerIdProvider workerIdProvider,
        MarkSPAAsRejectedMapper mapper,
        IPublishEndpoint publishEndpoint,
        IIdentityService identityService,
        ISPARepository repository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<MarkSPAAsRejectedRequest>
    {
        public async Task Handle(MarkSPAAsRejectedRequest request, CancellationToken cancellationToken)
        {
            var application = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (application == null || application.IsDeleted)
                throw new SPANotFoundException();
            
            if(application.StudyProgramOwnerId != identityService.UserId)
                workerIdProvider.Validate(identityService.UserId);

            application.MarkAsRejected(request.Reason);
            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(application);
            await publishEndpoint.Publish(@event,cancellationToken);
        }
    }
}
