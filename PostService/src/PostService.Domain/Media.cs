using Shared.Events.SharedObjects;

namespace PostService.Domain
{
    public class Media
    {
        public string ContainerName { get; private set; } = Post.MediaContainerName;
        public string BlobName { get; private set; } = null!;
        public MediaType Type { get; private set; }
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public string? TranscodedBlobName { get; private set; }
        public MediaInstruction Instruction { get; private set; } = null!;
        private readonly List<Thumbnail> _thumbnails = [];
        public IReadOnlyCollection<Thumbnail> Thumbnails => _thumbnails;

        private Media(){}

        public Media(string blobName, MediaType type, MediaInstruction instruction)
        {
            BlobName = blobName;
            Type = type;
            Instruction = instruction;
        }

        public void Set(
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            string? transcodedBlobName
        )
        {
            Metadata = metadata;
            ModerationResult = moderationResult;
            _thumbnails.AddRange(thumbnails);
            TranscodedBlobName = transcodedBlobName;
        }

        public bool IsPreprocessingCompleted() =>
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
                        Instruction.ModerationInstruction != null &&
                        Instruction.ModerationInstruction.IsValidModerationResult(ModerationResult)
                    )
                ) &&
                Instruction.ThumbnailInstructions.Count() == Thumbnails.Count() &&
                (
                    Type == MediaType.Image ||
                    Instruction.TranscodingInstruction == null ||
                    TranscodedBlobName != null
                )
            );
    }
}
