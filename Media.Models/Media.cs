using System.Text.Json.Serialization;

namespace Media.Models
{
    [method:JsonConstructor]
    public record Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings,
        MediaInstruction Instruction
    )
    {
        public Media Set(
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            IEnumerable<Transcoding> transcodings
        ) =>
            new(
                ContainerName,
                BlobName,
                Type,
                metadata,
                moderationResult,
                thumbnails,
                transcodings,
                Instruction
            );

        public static Media Create(string containerName, string blobName, MediaType type, MediaInstruction instruction) =>
            new(containerName, blobName, type, null, null, [], [], instruction);

    }
}
