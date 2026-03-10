using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.AddTranscoding
{
    internal class SetTranscodedBlobNameHandler(
        MediaPreprocessingCompletionEvaluator mediaPreprocessingCompletionEvaluator,
        AddTrascodingMapper mapper,
        IMediaRepository mediaRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<AddTrascodingRequest>
    {
        public async Task Handle(AddTrascodingRequest request, CancellationToken cancellationToken)
        {
            var media = 
                await mediaRepository.AddTranscoding(request.ContainerName, request.BlobName, request.Transcoding, cancellationToken) ??
                throw new MediaNotFoundException();

            if (mediaPreprocessingCompletionEvaluator.IsPreprocessingCompleted(media))
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
