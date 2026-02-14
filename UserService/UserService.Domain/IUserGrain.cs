namespace UserService.Domain
{
    [Alias("UserService.Domain.IUserGrain")]
    public interface IUserGrain : IGrainWithGuidKey
    {
        [Alias("Get")]Task<User> Get();
        [Alias("Create")]Task<User> Create(UserName username);
        [Alias("AddMedia")]Task<User> CreateMedia(Media media);
        [Alias("UpdateName")]Task<User> UpdateName(Name name);
        [Alias("UpdateUserName")]Task<User> UpdateUserName(UserName name);
        [Alias("SetMediaMatadata")]Task<User> SetMediaMatadata(string blobName, Metadata metadata);
        [Alias("SetMediaModerationResult")]Task<User> SetMediaModerationResult(string blobName, ModerationResult moderationResult);
        [Alias("AddMediaThumbnail")]Task<User> AddMediaThumbnail(string blobName, Thumbnail thumbnail);
    }
}
