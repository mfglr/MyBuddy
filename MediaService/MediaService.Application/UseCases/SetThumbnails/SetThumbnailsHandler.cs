using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetThumbnails
{
    internal class SetThumbnailsHandler(
        IPublishEndpoint publishEndpoint,
        SetThumbnailsMapper mapper,
        IMediaRepository mediaRepository
    ) : IRequestHandler<SetThumbnailsRequest>
    {
        public async Task Handle(SetThumbnailsRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new MediaNotFoundException();
            media.SetThumbnails(request.Thumbnails);
            await mediaRepository.UpdateAsync(media, cancellationToken);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
