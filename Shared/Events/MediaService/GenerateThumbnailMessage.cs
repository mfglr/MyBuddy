using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record GenerateThumbnailMessage(
        string ContainerName,
        string BlobName,
        ThumbnailInstruction Instruction
    );
}
