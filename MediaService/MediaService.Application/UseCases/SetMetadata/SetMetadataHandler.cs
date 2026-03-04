using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataHandler(
        SetMetadataMapper mapper,
        IMediaRepository mediaRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetMetadataRequest>
    {
        public async Task Handle(SetMetadataRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new MediaNotFoundException();
            media.SetMetadata(request.Metadata);
            await mediaRepository.UpdateAsync(media, cancellationToken);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
