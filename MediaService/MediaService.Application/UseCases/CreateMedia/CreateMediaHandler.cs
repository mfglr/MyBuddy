using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(CreateMediaMapper mapper, IPublishEndpoint publishEndpoint, IMediaRepository mediaRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var media = request.Media.Select(x => new Media(x.OwnerId, x.ContainerName, x.BlobName, x.Type, x.Instruction));
            await mediaRepository.CreateMedia(media, cancellationToken);

            var events = media.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
