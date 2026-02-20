using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsApproved
{
    internal class MarkSPAAsApprovedHandler(
        WorkerIdProvider workerIdProvider,
        IUnitOfWork unitOfWork,
        MarkSPAAsApprovedMapper mapper,
        IIdentityService identityService,
        ISPARepository repository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<MarkSPAAsApprovedRequest>
    {
        public async Task Handle(MarkSPAAsApprovedRequest request, CancellationToken cancellationToken)
        {
            var application = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (application == null || application.IsDeleted)
                throw new SPANotFoundException();

            workerIdProvider.Validate(identityService.UserId);

            application.MarkAsApproved();

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(application);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
