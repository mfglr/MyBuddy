using Media.Models;

namespace Shared.Events.MediaService
{
    public record MediaCreatedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    );
}
