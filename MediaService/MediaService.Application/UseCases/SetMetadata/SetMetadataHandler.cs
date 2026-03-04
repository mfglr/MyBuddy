using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataHandler(
        SetMetadataMapper mapper,
        IMediaListRepository mediaListRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetMetadataRequest>
    {
        public async Task Handle(SetMetadataRequest request, CancellationToken cancellationToken)
        {
            var mediaList = await mediaListRepository.SetMetadata(request.Id, request.BlobName, request.Metadata, cancellationToken);

            if (mediaList.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(mediaList);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
