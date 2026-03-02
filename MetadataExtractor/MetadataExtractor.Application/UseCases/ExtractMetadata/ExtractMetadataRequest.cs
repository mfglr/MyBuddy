using MediatR;
using Shared.Events.SharedObjects;

namespace MetadataExtractor.Application.UseCases.ExtractMetadata
{
    public record ExtractMetadataRequest(
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    ) : IRequest;
}
