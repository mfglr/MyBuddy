namespace PostMedia.Domain
{
    [Alias("PostMedia.Domain.IPostGrain")]
    public interface IPostGrain : IGrainWithGuidKey
    {
        [Alias("Get")]
        Task<Post> Get();
        [Alias("Create")]
        Task Create(IEnumerable<Media> media);
        [Alias("SetMetadata")]
        Task SetMetadata(string blobName, Metadata metadata);
        [Alias("SetModerationResult")]
        Task SetModerationResult(string blobName, ModerationResult moderationResult);
        [Alias("AddThumbnail")]
        Task AddThumbnail(string blobName, Thumbnail thumbnail);
        [Alias("SetTranscodedBlobName")]
        Task SetTranscodedBlobName(string blobName, string transcodedBlobName);
        [Alias("Delete")]
        Task Delete();
    }
}
