using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsAwaitingCapacityReservation
{
    internal class MarkSPAAsAwaitingCapacityReservationHandler(
        WorkerIdProvider workerIdProvider,
        IUnitOfWork unitOfWork,
        MarkSPAAsAwaitingCapacityReservationMapper mapper,
        IIdentityService identityService,
        ISPARepository repository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<MarkSPAAsAwaitingCapacityReservationRequest>
    {
        public async Task Handle(MarkSPAAsAwaitingCapacityReservationRequest request, CancellationToken cancellationToken)
        {
            var spa = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (spa == null || spa.IsDeleted)
                throw new SPANotFoundException();

            workerIdProvider.Validate(identityService.UserId);

            spa.MarkAsAwaitingCapacityReservation();

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(spa);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
