using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MetadataExtractionValidatedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata Metadata,
        MediaInstruction Instruction
    );
}
