using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MetadataExtractor.Application.UseCases.ExtractMetadata
{
    internal class ExtractMetadataHandler(IPublishEndpoint publishEndpoint, IBlobService blobService, IMetadataExtractor extractor) : IRequestHandler<ExtractMetadataRequest>
    {
        public async Task Handle(ExtractMetadataRequest request, CancellationToken cancellationToken)
        {
            using var stream = await blobService.ReadAsync(request.ContainerName, request.BlobName, cancellationToken);
            var metadata = await extractor.ExtractAsync(stream, cancellationToken);

            object @event;
            if (request.Instruction.MetadataInstruction.IsValidMetadata(metadata))
                @event = new MetadataExtractionValidatedEvent(request.ContainerName, request.BlobName, request.Type, metadata, request.Instruction);
            else
                @event = new MetadataExtractionInvalidatedEvent(request.ContainerName, request.BlobName, metadata);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
