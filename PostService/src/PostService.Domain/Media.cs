using Shared.Events.SharedObjects;

namespace PostService.Domain
{
    public class Media
    {
        public string ContainerName { get; private set; }
        public string BlobName { get; private set; } = null!;
        public MediaType Type { get; private set; }
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails { get; private set; }
        public string? TranscodedBlobName { get; private set; }
        public MediaInstruction Instruction { get; private set; }

        public Media(
            string containerName,
            string blobName,
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            string? transcodedBlobName,
            MediaInstruction instruction
        )
        {
            ContainerName = containerName;
            BlobName = blobName;
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = [.. thumbnails];
            TranscodedBlobName = transcodedBlobName;
            Instruction = instruction;
        }

        public Media(string blobName, MediaType type, MediaInstruction instruction)
        {
            ContainerName = Post.MediaContainerName;
            BlobName = blobName;
            Type = type;
            Thumbnails = [];
            Instruction = instruction;
        }
        public void Set(
            Metadata metadata,
            ModerationResult? moderationResult, 
            IEnumerable<Thumbnail> thumbnails,
            string? transcodedBlobName
        )
        {
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = [.. thumbnails];
            TranscodedBlobName = transcodedBlobName;
        }


        public bool IsValid =>
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
            Instruction.ThumbnailInstructions.Count == Thumbnails.Count &&
            (
                Type == MediaType.Image ||
                Instruction.TranscodingInstruction == null ||
                TranscodedBlobName != null
            );
    }
}
