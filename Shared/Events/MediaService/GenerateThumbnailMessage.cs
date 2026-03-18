using Media.Models;

namespace Shared.Events.MediaService
{
    public record GenerateThumbnailMessage(
        string ContainerName,
        string BlobName,
        ThumbnailInstruction Instruction
    );
}
