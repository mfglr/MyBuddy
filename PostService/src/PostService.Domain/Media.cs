using Newtonsoft.Json;
using Orleans;
using UserService.Domain;

namespace PostService.Domain
{
    [GenerateSerializer]
    [Alias("PostService.Domain.Media")]
    public class Media
    {
        [Id(0)]
        public string ContainerName { get; private set; }
        [Id(1)]
        public string BlobName { get; private set; }
        [Id(2)]
        public MediaType Type { get; private set; }
        [Id(3)]
        public string? TranscodedBlobName { get; private set; }
        [Id(4)]
        public Metadata? Metadata { get; private set; }
        [Id(5)]
        public ModerationResult? ModerationResult { get; private set; }
        [Id(6)]
        public List<Thumbnail> Thumbnails { get; private set; }
        
        public bool IsPreprocessingCompletedAndIsValid() =>
            TranscodedBlobName != null &&
            ModerationResult != null && ModerationResult.IsValid() &&
            Thumbnails.Count == 4 &&
            Metadata != null && Metadata.IsValid();

        [JsonConstructor]
        public Media(string containerName, string blobName, MediaType type, string transcodedBlobName, Metadata? metadata, ModerationResult? moderationResult, List<Thumbnail> thumbnails)
        {
            ContainerName = containerName;
            BlobName = blobName;
            Type = type;
            TranscodedBlobName = transcodedBlobName;
            Metadata = metadata;
            ModerationResult = moderationResult;
            Thumbnails = thumbnails;
        }

        public Media(string blobName, MediaType type)
        {
            ContainerName = Post.MediaContainerName;
            BlobName = blobName;
            Thumbnails = [];
            Type = type;
        }

        public void SetTranscodedBlobName(string transcodedBlobName) => TranscodedBlobName = transcodedBlobName;
        public void SetMetadata(Metadata metadata) => Metadata = metadata;
        public void SetModerationResult(ModerationResult moderationResult) => ModerationResult = moderationResult;
        public void AddThumbnail(Thumbnail thumbnail) => Thumbnails.Add(thumbnail);
    }
}
