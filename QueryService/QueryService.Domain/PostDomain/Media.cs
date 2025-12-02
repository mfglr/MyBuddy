using Shared.Objects;

namespace QueryService.Domain.PostDomain
{
    public class Media
    {
        public string ContainerName { get; private set; } = null!;
        public string BlobName { get; private set; } = null!;
        public MediaType Type { get; private set; }
        public string? TranscodedBlobName { get; private set; }
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails { get; private set; } = null!;

        private Media() { }
        

        public Media(string blobName, MediaType type)
        {
            ContainerName = Post.MediaContainerName;
            BlobName = blobName;
            Type = type;
            Thumbnails = [];
        }

        public Media Set(string? transcodedBlobName, Metadata metadata, ModerationResult moderationResult, IEnumerable<Thumbnail> thumbnails) => 
            new()
            {
                ContainerName = ContainerName,
                BlobName = BlobName,
                Type = Type,
                TranscodedBlobName = transcodedBlobName,
                Metadata = metadata,
                ModerationResult = moderationResult,
                Thumbnails = [.. thumbnails]
            };
    }
}
