using Orleans;

namespace PostService.Domain
{
    [Alias("PostService.Domain.IPostGrain")]
    public interface IPostGrain : IGrainWithGuidKey
    {
        [Alias("Get")]
        Task<Post> Get();

        [Alias("Create")]
        Task Create(Guid userId, Content? content, List<Media> media);
        [Alias("Delete")]
        Task Delete();
        [Alias("Restore")]
        Task Restore();

        [Alias("SetContentModerationResult")]
        Task SetContentModerationResult(ModerationResult result);
        [Alias("UpdateContent")]
        Task UpdateContent(Content content);

        [Alias("SetMediaTranscodedBlobName")]
        Task SetMediaTranscodedBlobName(string blobName, string transcodedBlobName);
        [Alias("SetMediaMetadata")]
        Task SetMediaMetadata(string blobName, Metadata metadata);
        [Alias("SetMediaModerationResult")]
        Task SetMediaModerationResult(string blobName, ModerationResult result);
        [Alias("AddThumbnail")]
        Task AddThumbnail(string blobName, Thumbnail thumbnail);
    }
}
