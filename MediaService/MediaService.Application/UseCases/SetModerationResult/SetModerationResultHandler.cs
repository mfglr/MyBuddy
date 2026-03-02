using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultHandler(SetModerationResultMapper mapper, IPublishEndpoint publishEndpoint, IMediaRepository mediaRepository,IUnitOfWork unitOfWork) : IRequestHandler<SetModerationResultRequest>
    {
        public async Task Handle(SetModerationResultRequest request, CancellationToken cancellationToken)
        {
            var media =
                await mediaRepository.GetAsync(request.ContainerName, request.BlobName, cancellationToken) ??
                throw new MediaNotFoundException();

            media.SetModerationResult(request.ModerationResult);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
