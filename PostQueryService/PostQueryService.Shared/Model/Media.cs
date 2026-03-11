using Shared.Events.SharedObjects;

namespace PostQueryService.Shared.Model
{
    public class Media
    {
        public string ContainerName { get; private set; } = null!;
        public string BlobName { get; private set; } = null!;
        public MediaType Type { get; private set; }
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails { get; private set; } = [];
        public IReadOnlyCollection<Transcoding> Transcodings { get; private set; } = [];

        private Media() { }

        public Media(
            string containerName,
            string blobName,
            MediaType type,
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            IEnumerable<Transcoding> transcodings
        )
        {
            ContainerName = containerName;
            BlobName = blobName;
            Type = type;
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = [.. thumbnails];
            Transcodings = [.. transcodings];
        }
    }
}
