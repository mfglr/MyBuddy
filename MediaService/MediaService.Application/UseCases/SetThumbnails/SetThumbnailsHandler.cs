using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetThumbnails
{
    internal class SetThumbnailsHandler(
        IPublishEndpoint publishEndpoint,
        SetThumbnailsMapper mapper,
        IMediaListRepository mediaListRepository
    ) : IRequestHandler<SetThumbnailsRequest>
    {
        public async Task Handle(SetThumbnailsRequest request, CancellationToken cancellationToken)
        {
            var mediaList = await mediaListRepository.SetThumbnails(request.Id, request.BlobName, request.Thumbnails, cancellationToken);

            if (mediaList.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(mediaList);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
