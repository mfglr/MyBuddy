using MassTransit;
using MediatR;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Application.UseCases.CreateSPI
{
    internal class CreateSPIHandler(
        IIdentityService identityService,
        IPublishEndpoint publishEndpoint,
        IUnitOfWork unitOfWork,
        ISPIRepository spiRepsitory,
        CreateSPIMapper mapper,
        SPICreatorDomainService spiCreator
    ) : IRequestHandler<CreateSPIRequest>
    {
        public async Task Handle(CreateSPIRequest request, CancellationToken cancellationToken)
        {
            var studyProgramOwnerId = identityService.UserId;
            var spi = await spiCreator.CreateAsync(request.StudyProgramId, request.UserId, studyProgramOwnerId, cancellationToken);
            await spiRepsitory.CreateAsync(spi, cancellationToken);
            
            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(spi);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
