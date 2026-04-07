using MassTransit;
using Media.Models;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultHandler(
        SetModerationResult_MessageGenerator messageGenerator,
        MediaProcessingCompletionEvaluator mediaProcessingCompletionEvaluator,
        SetModerationResultMapper mapper,
        IPublishEndpoint publishEndpoint,
        IMediaRepository mediaRepository
    ) : IRequestHandler<SetModerationResultRequest>
    {
        public async Task Handle(SetModerationResultRequest request, CancellationToken cancellationToken)
        {
            var media =
                await mediaRepository.GetForUpdateByIdAsync(request.ContainerName, request.BlobName, cancellationToken) ?? 
                throw new MediaNotFoundException();

            media.SetModerationResult(request.ModerationResult);

            var events = new List<object>();
            if (mediaProcessingCompletionEvaluator.IsProcessingCompleted(media.Context))
                events.Add(mapper.Map(media));
            events.AddRange(messageGenerator.GenerateMessages(media));
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
