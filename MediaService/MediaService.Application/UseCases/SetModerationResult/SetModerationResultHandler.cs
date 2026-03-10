using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultHandler(
        SetModerationResult_MessageGenerator messageGenerator,
        MediaPreprocessingCompletionEvaluator mediaPreprocessingCompletionEvaluator,
        SetModerationResultMapper mapper,
        IPublishEndpoint publishEndpoint,
        IMediaRepository mediaRepository
    ) : IRequestHandler<SetModerationResultRequest>
    {
        public async Task Handle(SetModerationResultRequest request, CancellationToken cancellationToken)
        {
            var media =
                await mediaRepository.SetModerationResult(request.ContainerName, request.BlobName, request.ModerationResult, cancellationToken) ?? 
                throw new MediaNotFoundException();

            var events = new List<object>();
            if (mediaPreprocessingCompletionEvaluator.IsPreprocessingCompleted(media))
                events.Add(mapper.Map(media));
            events.AddRange(messageGenerator.GenerateMessages(media));
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
