using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsPendingApprovel
{
    internal class MarkSPAAsPendingApprovelHandler(
        WorkerIdProvider workerIdProvider,
        IUnitOfWork unitOfWork,
        MarkSPAAsPendingApprovelMapper mapper,
        IIdentityService identityService,
        ISPARepository repository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<MarkSPAAsPendingApprovelRequest>
    {
        public async Task Handle(MarkSPAAsPendingApprovelRequest request, CancellationToken cancellationToken)
        {
            var application = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (application == null || application.IsDeleted)
                throw new SPANotFoundException();

            workerIdProvider.Validate(identityService.UserId);

            application.MarkAsPendingApprovel();

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(application);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
