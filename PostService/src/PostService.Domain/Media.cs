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
        public IReadOnlyCollection<Transcoding> Transcodings { get; private set; }
        public MediaInstruction Instruction { get; private set; }

        public Media(
            string containerName,
            string blobName,
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            IEnumerable<Transcoding> transcodings,
            MediaInstruction instruction
        )
        {
            ContainerName = containerName;
            BlobName = blobName;
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = [.. thumbnails];
            Transcodings = [.. transcodings];
            Instruction = instruction;
        }

        public Media(string blobName, MediaType type, MediaInstruction instruction)
        {
            ContainerName = Post.MediaContainerName;
            BlobName = blobName;
            Type = type;
            Thumbnails = [];
            Transcodings = [];
            Instruction = instruction;
        }

        public void Set(
            Metadata? metadata,
            ModerationResult? moderationResult, 
            IEnumerable<Thumbnail> thumbnails,
            IEnumerable<Transcoding> transcodings
        )
        {
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = [.. thumbnails];
            Transcodings = [.. transcodings];
        }

        public bool IsValid =>
            Instruction.MetadataInstruction == null ||
            (
                Metadata != null &&
                Instruction.MetadataInstruction.IsValid(Metadata)
            ) &&
            (
                Instruction.ModerationInstruction == null ||
                (
                    ModerationResult != null &&
                    Instruction.ModerationInstruction.IsValid(ModerationResult)
                )
            ) &&
            (
                Instruction.ThumbnailInstructions == null ||
                Instruction.ThumbnailInstructions.Count == Thumbnails.Count
            ) &&
            (
                Type == MediaType.Image ||
                Instruction.TranscodingInstructions == null ||
                Instruction.TranscodingInstructions.Count == Transcodings.Count
            );
    }
}
