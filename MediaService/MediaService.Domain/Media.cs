using Shared.Events.SharedObjects;

namespace MediaService.Domain
{
    public class Media(string blobName, MediaType type, MediaInstruction instruction)
    {
        public string BlobName { get; private set; } = blobName;
        public MediaType Type { get; private set; } = type;
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails = [];
        public string? TranscodedBlobName { get; private set; }
        public MediaInstruction Instruction { get; private set; } = instruction;

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
