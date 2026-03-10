using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.AddThumbnail
{
    internal class AddThumbnailHandler(
        MediaPreprocessingCompletionEvaluator mediaPreprocessingCompletionEvaluator,
        IPublishEndpoint publishEndpoint,
        AddThumbnailMapper mapper,
        IMediaRepository mediaRepository
    ) : IRequestHandler<AddThumbnailRequest>
    {
        public async Task Handle(AddThumbnailRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.AddThumbnail(request.ContainerName, request.BlobName, request.Thumbnail, cancellationToken) ?? throw new MediaNotFoundException();

            if (mediaPreprocessingCompletionEvaluator.IsPreprocessingCompleted(media))
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
