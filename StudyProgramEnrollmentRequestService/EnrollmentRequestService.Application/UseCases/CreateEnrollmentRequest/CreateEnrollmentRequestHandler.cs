using EnrollmentRequestService.Domain;
using MassTransit;
using MediatR;

namespace EnrollmentRequestService.Application.UseCases.CreateEnrollmentRequest
{
    internal class CreateEnrollmentRequestHandler(CreateEnrollmentRequestMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, IEnrollmentRequestRepository repository, EnrollmentRequestCreatorDomainService domainService, IUnitOfWork unitOfWork) : IRequestHandler<CreateEnrollmentRequest_Request>
    {
        public async Task Handle(CreateEnrollmentRequest_Request request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var enrollmentRequest = await domainService.CreateAsync(request.StudyProgramId, userId, request.StudyProgramOwnerId, cancellationToken);
            await repository.CreateAsync(enrollmentRequest, cancellationToken);

            var @event = mapper.Map(enrollmentRequest);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
