using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultHandler(
        SetModerationResultMapper mapper,
        IPublishEndpoint publishEndpoint,
        IMediaListRepository mediaListRepository
    ) : IRequestHandler<SetModerationResultRequest>
    {
        public async Task Handle(SetModerationResultRequest request, CancellationToken cancellationToken)
        {
            var mediaList = await mediaListRepository.SetModerationResult(request.Id, request.BlobName, request.ModerationResult,cancellationToken);

            if (mediaList.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(mediaList);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
