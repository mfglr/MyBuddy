using MassTransit;
using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.CreateSPA
{
    internal class CreateSPAHandler(CreateSPAMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, ISPARepository repository, SPACreatorDomainService domainService, IUnitOfWork unitOfWork) : IRequestHandler<CreateSPARequest>
    {
        public async Task Handle(CreateSPARequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var studyProgramApplication = await domainService.CreateAsync(request.StudyProgramId, userId, request.StudyProgramOwnerId, cancellationToken);
            await repository.CreateAsync(studyProgramApplication, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgramApplication);
            await publishEndpoint.Publish(@event, cancellationToken);

        }
    }
}
