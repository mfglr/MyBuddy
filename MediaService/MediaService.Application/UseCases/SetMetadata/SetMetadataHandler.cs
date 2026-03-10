using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataHandler(
        SetMetadata_MessageGenerator messageGenerator,
        MediaPreprocessingCompletionEvaluator mediaPreprocessingCompletionEvaluator,
        SetMetadataMapper mapper,
        IMediaRepository mediaRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetMetadataRequest>
    {
        public async Task Handle(SetMetadataRequest request, CancellationToken cancellationToken)
        {
            var media = 
                await mediaRepository.SetMetadata(request.ContainerName,request.BlobName, request.Metadata, cancellationToken) ??
                throw new MediaNotFoundException();

            var events = new List<object>();
            if (mediaPreprocessingCompletionEvaluator.IsPreprocessingCompleted(media))
                events.Add(mapper.Map(media));
            events.AddRange(messageGenerator.GenerateMessages(media));
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
