using System.Text.Json.Serialization;

namespace Media.Models
{
    [method:JsonConstructor]
    public record MediaProcessingContext(
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings,
        MediaInstruction Instruction
    )
    {

        public IEnumerable<string> BlobNames =>
            [.. Thumbnails.Select(x => x.BlobName), .. Transcodings.Select(x => x.BlobName)];

        public MediaProcessingContext SetMetadata(Metadata metadata) =>
            new(
                Type,
                metadata,
                ModerationResult,
                Thumbnails,
                Transcodings,
                Instruction
            );

        public MediaProcessingContext SetModerationResult(ModerationResult moderationResult) =>
            new(
                Type,
                Metadata,
                moderationResult,
                Thumbnails,
                Transcodings,
                Instruction
            );

        public MediaProcessingContext AddThumbnail(Thumbnail thumbnail) =>
            new(
                Type,
                Metadata,
                ModerationResult,
                [.. Thumbnails, thumbnail],
                Transcodings,
                Instruction
            );
        public MediaProcessingContext AddTranscoding(Transcoding transcoding) =>
            new(
                Type,
                Metadata,
                ModerationResult,
                Thumbnails,
                [..Transcodings,transcoding],
                Instruction
            );

        public MediaProcessingContext Set(
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            IEnumerable<Transcoding> transcodings
        ) =>
            new(
                Type,
                metadata,
                moderationResult,
                [..thumbnails],
                [..transcodings],
                Instruction
            );

        public static MediaProcessingContext Create(MediaType type, MediaInstruction instruction) =>
            new(type, null, null, [], [], instruction);
    }
}
