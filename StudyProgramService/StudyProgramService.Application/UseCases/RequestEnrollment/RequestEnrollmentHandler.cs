using MassTransit;
using MediatR;
using StudyProgramService.Application.UseCases.IncreaseEnrollmentCount;
using StudyProgramService.Domain.EnrollmentRequestAggregate.Abstracts;
using StudyProgramService.Domain.EnrollmentRequestAggregate.Entities;
using StudyProgramService.Domain.EnrollmentRequestAggregate.Exceptions;

namespace StudyProgramService.Application.UseCases.RequestEnrollment
{
    internal class RequestEnrollmentHandler(RequestEnrollmentMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, IEnrollmentRequestRepository enrollmentRequestRepository) : IRequestHandler<RequestEnrollmentRequest>
    {
        public async Task Handle(RequestEnrollmentRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;

            if (!await enrollmentRequestRepository.ExistAsync(request.Id, userId, cancellationToken))
                throw new DuplicateEnrollmentRequestException();

            var enrollmentRequest = new EnrollmentRequest(request.Id, userId);
            enrollmentRequest.Create();
            await enrollmentRequestRepository.CreateAsync(enrollmentRequest, cancellationToken);

            var @event = mapper.Map(enrollmentRequest);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
