using Shared.Events.SharedObjects;

namespace MediaService.Domain
{
    public class Media(MediaId mediaId, Guid ownerId, MediaType type, MediaInstruction instruction)
    {
        public MediaId Id { get; private set; } = mediaId;
        public Guid OwnerId { get; private set; } = ownerId;
        public int Version { get; private set; } = 1;
        public MediaType Type { get; private set; } = type;
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails = [];
        public string? TranscodedBlobName { get; private set; }
        public MediaInstruction Instruction { get; private set; } = instruction;

        public void SetMetadata(Metadata metadata)
        {
            Metadata = metadata;
            Version++;
        }
        public void SetModerationResult(ModerationResult? moderationResult)
        {
            ModerationResult = moderationResult;
            Version++;
        }
        public void SetThumbnails(IEnumerable<Thumbnail> thumbnails)
        {
            Thumbnails = [.. thumbnails];
            Version++;
        }
        public void SetTranscodedBlobName(string transcodedBlobName)
        {
            TranscodedBlobName = transcodedBlobName;
            Version++;
        }

        public bool IsPreprocessingCompleted =>
            (
                Metadata != null &&
                !Instruction.MetadataInstruction.IsValidMetadata(Metadata)
            ) ||
            (
                Metadata != null &&
                Instruction.MetadataInstruction.IsValidMetadata(Metadata) &&
                ModerationResult != null &&
                Instruction.ModerationInstruction != null &&
                !Instruction.ModerationInstruction.IsValidModerationResult(ModerationResult)
            ) ||
            (
                Metadata != null &&
                Instruction.MetadataInstruction.IsValidMetadata(Metadata) &&
                (
                    Instruction.ModerationInstruction == null ||
                    (
                        ModerationResult != null &&
                        Instruction.ModerationInstruction.IsValidModerationResult(ModerationResult)
                    )
                ) &&
                Instruction.ThumbnailInstructions.Count == Thumbnails.Count &&
                (
                    Type == MediaType.Image ||
                    Instruction.TranscodingInstruction == null ||
                    TranscodedBlobName != null
                )
            );
    }
}
