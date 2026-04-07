using Media.Models;

namespace MediaService.Domain
{
    public class Media
    {
        public string ContainerName { get; private set; } = null!;
        public string BlobName { get; private set; } = null!;
        public Guid OwnerId { get; private set; }
        public MediaProcessingContext Context { get; private set; } = null!;

        public void SetMetadata(Metadata metadata) => Context = Context.SetMetadata(metadata);
        public void SetModerationResult(ModerationResult moderationResult) => Context = Context.SetModerationResult(moderationResult);
        public void AddThumbnail(Thumbnail thumbnail) => Context = Context.AddThumbnail(thumbnail);
        public void AddTranscoding(Transcoding transcoding) => Context = Context.AddTranscoding(transcoding);

        private Media(){}

        public Media(string containerName, string blobName, Guid ownerId, MediaProcessingContext context)
        {
            ContainerName = containerName;
            BlobName = blobName;
            OwnerId = ownerId;
            Context = context;
        }
    }
}
