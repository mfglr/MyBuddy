using MassTransit;
using MediatR;

namespace MetadataExtractor.Application.UseCases.ExtractMetadata
{
    internal class ExtractMetadataHandler(
        ExtractMetadataMapper mapper,
        IPublishEndpoint publishEndpoint,
        IBlobService blobService,
        IMetadataExtractor extractor
    ) : IRequestHandler<ExtractMetadataRequest>
    {
        public async Task Handle(ExtractMetadataRequest request, CancellationToken cancellationToken)
        {
            using var stream = await blobService.ReadAsync(request.ContainerName, request.BlobName, cancellationToken);
            var metadata = await extractor.ExtractAsync(stream, cancellationToken);
            
            var @event = mapper.Map(request, metadata);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
