using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetThumbnails
{
    internal class SetThumbnailsHandler(IPublishEndpoint publishEndpoint, SetThumbnailsMapper mapper, IMediaRepository mediaRepository,IUnitOfWork unitOfWork) : IRequestHandler<SetThumbnailsRequest>
    {
        public async Task Handle(SetThumbnailsRequest request, CancellationToken cancellationToken)
        {
            var media =
                await mediaRepository.GetAsync(request.ContainerName, request.BlobName, cancellationToken) ??
                throw new MediaNotFoundException();

            media.SetThumbnails(request.Thumbnails);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
