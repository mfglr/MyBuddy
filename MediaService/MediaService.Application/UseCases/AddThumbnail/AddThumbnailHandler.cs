using MassTransit;
using Media.Models;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.AddThumbnail
{
    internal class AddThumbnailHandler(
        MediaProcessingCompletionEvaluator mediaProcessingCompletionEvaluator,
        IPublishEndpoint publishEndpoint,
        AddThumbnailMapper mapper,
        IMediaRepository mediaRepository
    ) : IRequestHandler<AddThumbnailRequest>
    {
        public async Task Handle(AddThumbnailRequest request, CancellationToken cancellationToken)
        {
            var media = 
                await mediaRepository.GetForUpdateByIdAsync(request.ContainerName,request.BlobName, cancellationToken) ??
                throw new MediaNotFoundException();

            media.AddThumbnail(request.Thumbnail);

            if (mediaProcessingCompletionEvaluator.IsProcessingCompleted(media.Context))
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
