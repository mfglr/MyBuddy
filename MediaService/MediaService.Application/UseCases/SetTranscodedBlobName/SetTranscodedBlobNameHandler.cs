using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    internal class SetTranscodedBlobNameHandler(SetTranscodedBlobNameMapper mapper, IUnitOfWork unitOfWork, IMediaRepository mediaRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<SetTranscodedBlobNameRequest>
    {
        public async Task Handle(SetTranscodedBlobNameRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetAsync(request.ContainerName, request.BlobName, cancellationToken) ?? throw new MediaNotFoundException();
            media.SetTranscodedBlobName(request.TranscodedBlobName);

            if (media.IsPreprocessingCompleted)
            {
                var @event = mapper.Map(media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
