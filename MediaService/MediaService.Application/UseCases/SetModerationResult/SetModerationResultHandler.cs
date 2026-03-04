using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultHandler(
        SetModerationResultMapper mapper,
        IPublishEndpoint publishEndpoint,
        IMediaRepository mediaRepository
    ) : IRequestHandler<SetModerationResultRequest>
    {
        public async Task Handle(SetModerationResultRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetByIdAsync(request.Id,cancellationToken) ?? throw new MediaNotFoundException();
            media.SetModerationResult(request.ModerationResult);
            await mediaRepository.UpdateAsync(media, cancellationToken);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
