using MassTransit;
using MediaService.Application.UseCases.SetModerationResult;
using MediaService.Application.UseCases.SetThumbnails;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataHandler(SetMetadataMapper mapper, IUnitOfWork unitOfWork, IMediaRepository mediaRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<SetMetadataRequest>
    {
        public async Task Handle(SetMetadataRequest request, CancellationToken cancellationToken)
        {
            var media = 
                await mediaRepository.GetAsync(request.ContainerName, request.BlobName, cancellationToken) ??
                throw new MediaNotFoundException();

            media.SetMetadata(request.Metadata);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
