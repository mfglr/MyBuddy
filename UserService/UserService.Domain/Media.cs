using Shared.Events.SharedObjects;

namespace UserService.Domain
{
    public class Media(string blobName, MediaType type, MediaInstruction instruction)
    {
        public string ContainerName { get; private set; } = User.MediaContainerName;
        public string BlobName { get; private set; } = blobName;
        public MediaType Type { get; private set; } = type;
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails { get; private set; } = [];
        public MediaInstruction Instruction { get; private set; } = instruction;

        public void Set(
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails
        )
        {
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = [.. thumbnails];
        }
    }
}
