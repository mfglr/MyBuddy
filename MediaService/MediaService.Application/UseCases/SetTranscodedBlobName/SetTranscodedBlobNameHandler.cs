using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    internal class SetTranscodedBlobNameHandler(
        SetTranscodedBlobNameMapper mapper,
        IMediaRepository mediaRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetTranscodedBlobNameRequest>
    {
        public async Task Handle(SetTranscodedBlobNameRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new MediaNotFoundException();
            media.SetTranscodedBlobName(request.TranscodedBlobName);
            await mediaRepository.UpdateAsync(media, cancellationToken);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
