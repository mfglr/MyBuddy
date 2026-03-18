using Media.Models;

namespace Shared.Events.MediaService
{
    public record TranscodeVideoMessage(
        string ContainerName,
        string BlobName,
        TranscodingInstruction Instruction
    );
}
