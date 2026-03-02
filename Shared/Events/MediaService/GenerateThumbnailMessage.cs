using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record GenerateThumbnailMessage(
        ThumbnailInstruction Instruction
    );
}
