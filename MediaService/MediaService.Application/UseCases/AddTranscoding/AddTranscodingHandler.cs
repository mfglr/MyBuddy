using MassTransit;
using Media.Models;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.AddTranscoding
{
    internal class SetTranscodedBlobNameHandler(
        MediaProcessingCompletionEvaluator mediaPprocessingCompletionEvaluator,
        AddTrascodingMapper mapper,
        IMediaRepository mediaRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<AddTrascodingRequest>
    {
        public async Task Handle(AddTrascodingRequest request, CancellationToken cancellationToken)
        {
            var media = 
                await mediaRepository.GetForUpdateByIdAsync(request.ContainerName, request.BlobName, cancellationToken) ??
                throw new MediaNotFoundException();

            media.AddTranscoding(request.Transcoding);

            if (mediaPprocessingCompletionEvaluator.IsProcessingCompleted(media.Context))
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
