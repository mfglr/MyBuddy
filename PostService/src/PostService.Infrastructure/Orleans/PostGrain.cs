using Orleans;
using Orleans.Providers;
using PostService.Domain;

namespace PostService.Infrastructure.Orleans
{
    [StorageProvider(ProviderName = "PostStorage")]
    internal class PostGrain : Grain<Post>, IPostGrain
    {
        public Task<Post> Get() => Task.FromResult(State);

        public Task Create(Guid userId, Content? content, List<Media> media)
        {
            State = new Post(userId, content, media);
            return WriteStateAsync();
        }
        public Task Delete()
        {
            State.Delete();
            return WriteStateAsync();
        }
        public Task Restore()
        {
            State.Restore();
            return WriteStateAsync();
        }

        public Task SetContentModerationResult(ModerationResult result)
        {
            State.SetContentModerationResult(result);
            return WriteStateAsync();
        }
        public Task UpdateContent(Content content)
        {
            State.UpdateContent(content);
            return WriteStateAsync();
        }

        public Task AddThumbnail(string blobName, Thumbnail thumbnail)
        {
            State.AddThumbnail(blobName, thumbnail);
            return WriteStateAsync();
        }
        public Task SetMediaMetadata(string blobName, Metadata metadata)
        {
            State.SetMediaMetadata(blobName, metadata);
            return WriteStateAsync();
        }
        public Task SetMediaModerationResult(string blobName, ModerationResult result)
        {
            State.SetMediaModerationResult(blobName, result);
            return WriteStateAsync();
        }
        public Task SetMediaTranscodedBlobName(string blobName, string transcodedBlobName)
        {
            State.SetMediaTranscodedBlobName(blobName, transcodedBlobName);
            return WriteStateAsync();
        }
    }
}
