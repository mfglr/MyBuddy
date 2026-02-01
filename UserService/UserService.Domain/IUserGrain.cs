namespace UserService.Domain
{
    [Alias("UserService.Domain.IUserGrain")]
    public interface IUserGrain : IGrainWithGuidKey
    {
        [Alias("Get")]Task<User> Get();
        [Alias("Create")]Task Create(UserName username);
        [Alias("AddMedia")]Task CreateMedia(Media media);
        [Alias("UpdateName")]Task UpdateName(Name name);
        [Alias("SetMediaMatadata")]Task SetMediaMatadata(string blobName, Metadata metadata);
        [Alias("SetMediaModerationResult")]Task SetMediaModerationResult(string blobName, ModerationResult moderationResult);
        [Alias("AddMediaThumbnail")]Task AddMediaThumbnail(string blobName, Thumbnail thumbnail);
    }
}
