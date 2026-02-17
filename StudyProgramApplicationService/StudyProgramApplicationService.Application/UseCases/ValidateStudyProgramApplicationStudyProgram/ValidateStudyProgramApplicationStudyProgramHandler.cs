using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.ValidateStudyProgramApplicationStudyProgram
{
    internal class ValidateStudyProgramApplicationStudyProgramHandler(ValidateStudyProgramApplicationStudyProgramMapper mapper,IPublishEndpoint publishEndpoint,  WorkerIdProvider workerIdProvider, IIdentityService identityService, IStudyProgramApplicationRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<ValidateStudyProgramApplicationStudyProgramRequest>
    {
        public async Task Handle(ValidateStudyProgramApplicationStudyProgramRequest request, CancellationToken cancellationToken)
        {
            workerIdProvider.Validate(identityService.UserId);

            var application = await repository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken);
            if (application == null) return;

            application.MarkAsValidatedByStudyProgram();

            if (application.IsValidated)
            {
                var @event = mapper.Map(application);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
