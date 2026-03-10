using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record TranscodeVideoMessage(
        string ContainerName,
        string BlobName,
        TranscodingInstruction Instruction
    );
}
