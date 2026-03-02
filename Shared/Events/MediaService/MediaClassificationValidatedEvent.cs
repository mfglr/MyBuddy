using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaClassificationValidatedEvent(
        string ContainerName,
        string BlobName,
        MediaType Type,
        ModerationResult? ModerationResult,
        MediaInstruction Instruction
    );
}
