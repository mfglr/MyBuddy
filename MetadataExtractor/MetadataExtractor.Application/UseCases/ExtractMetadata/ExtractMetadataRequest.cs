using MediatR;

namespace MetadataExtractor.Application.UseCases.ExtractMetadata
{
    public record ExtractMetadataRequest(
        string ContainerName,
        string BlobName
    ) : IRequest;
}
