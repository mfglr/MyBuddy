using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MetadataExtractionValidatedEvent(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata Metadata,
        MediaInstruction Instruction
    );
}
