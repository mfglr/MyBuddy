using Shared.Events.SharedObjects;

namespace MediaService.Domain
{
    public class Media
    {
        public int Version { get; private set; }
        public Guid OwnerId { get; private set; }
        public string ContainerName { get; private set; } = null!;
        public string BlobName { get; private set; } = null!;
        public MediaType Type { get; private set; }
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public string? TranscodedBlobName { get; private set; }
        private readonly List<Thumbnail> _thumbnails = [];
        public IReadOnlyCollection<Thumbnail> Thumbnails => _thumbnails;
        public MediaInstruction Instruction { get; private set; } = null!;

        private Media(){ }

        public Media(Guid ownerId, string containerName, string blobName, MediaType type, MediaInstruction instruction)
        {
            OwnerId = ownerId;
            ContainerName = containerName;
            BlobName = blobName;
            Type = type;
            Instruction = instruction;
            Version = 1;
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
        public void SetTranscodedBlobName(string blobName)
        {
            TranscodedBlobName = blobName;
            Version++;
        }
        public void SetThumbnails(IEnumerable<Thumbnail> thumbnails)
        {
            _thumbnails.AddRange(thumbnails);
            Version++;
        }
    }
}
