using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record ClassifyMediaMessage(
        string ContainerName,
        string BlobName,
        MediaType Type,
        ModerationInstruction Instruction
    );
}
