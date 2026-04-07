using MassTransit;
using Media.Models;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataHandler(
        SetMetadata_MessageGenerator messageGenerator,
        MediaProcessingCompletionEvaluator mediaProcessingCompletionEvaluator,
        SetMetadataMapper mapper,
        IMediaRepository mediaRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetMetadataRequest>
    {
        public async Task Handle(SetMetadataRequest request, CancellationToken cancellationToken)
        {
            var media = 
                await mediaRepository.GetForUpdateByIdAsync(request.ContainerName,request.BlobName, cancellationToken) ??
                throw new MediaNotFoundException();
            media.SetMetadata(request.Metadata);

            var events = new List<object>();
            if (mediaProcessingCompletionEvaluator.IsProcessingCompleted(media.Context))
                events.Add(mapper.Map(media));
            events.AddRange(messageGenerator.GenerateMessages(media));
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
