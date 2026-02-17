using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.CreateStudyProgramApplication
{
    internal class CreateStudyProgramApplicationHandler(CreateStudyProgramApplicationMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, IStudyProgramApplicationRepository repository, StudyProgramApplicationCreatorDomainService domainService, IUnitOfWork unitOfWork) : IRequestHandler<CreateStudyProgramApplicationRequest>
    {
        public async Task Handle(CreateStudyProgramApplicationRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var studyProgramApplication = await domainService.CreateAsync(request.StudyProgramId, userId, request.StudyProgramOwnerId, cancellationToken);
            await repository.CreateAsync(studyProgramApplication, cancellationToken);

            var @event = mapper.Map(studyProgramApplication);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
