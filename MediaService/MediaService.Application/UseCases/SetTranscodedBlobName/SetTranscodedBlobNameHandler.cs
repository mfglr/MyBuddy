using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    internal class SetTranscodedBlobNameHandler(
        SetTranscodedBlobNameMapper mapper,
        IMediaListRepository mediaListRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetTranscodedBlobNameRequest>
    {
        public async Task Handle(SetTranscodedBlobNameRequest request, CancellationToken cancellationToken)
        {
            var mediaList = await mediaListRepository.SetTranscodedBlobName(request.Id, request.BlobName, request.TranscodedBlobName, cancellationToken);

            if (mediaList.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(mediaList);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}
