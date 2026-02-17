using EnrollmentRequestService.Domain;
using MassTransit;
using MediatR;

namespace EnrollmentRequestService.Application.UseCases.MarkAsValidatedByStudyProgram
{
    internal class MarkAsValidatedByStudyProgramHandler(MarkAsValidatedByStudyProgramMapper mapper,IPublishEndpoint publishEndpoint,  WorkerIdProvider workerIdProvider, IIdentityService identityService, IEnrollmentRequestRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<MarkAsValidatedByStudyProgramRequest>
    {
        public async Task Handle(MarkAsValidatedByStudyProgramRequest request, CancellationToken cancellationToken)
        {
            workerIdProvider.Validate(identityService.UserId);

            var enrollmentRequest = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (enrollmentRequest == null) return;

            enrollmentRequest.MarkAsValidatedByStudyProgram();

            if (enrollmentRequest.IsValidated)
            {
                var @event = mapper.Map(enrollmentRequest);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
