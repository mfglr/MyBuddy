using Orleans.Providers;
using UserService.Domain;

namespace UserService.Infrastructure.Grains
{
    [StorageProvider(ProviderName = "UserStorage")]
    internal class UserGrain : Grain<User>, IUserGrain
    {
        public Task<User> Get() => Task.FromResult(State);

        public async Task<User> Create(UserName userName)
        {
            State = new User(this.GetPrimaryKey(), userName);
            await WriteStateAsync();
            return State;
        }

        public async Task<User> CreateMedia(Media media)
        {
            if (State == default)
                throw new UserNotFoundException();
            State.CreateMedia(media);
            await WriteStateAsync();
            return State;
        }

        public async Task<User> UpdateName(Name name)
        {
            if (State == default)
                throw new UserNotFoundException();
            State.UpdateName(name);
            await WriteStateAsync();
            return State;
        }

        public async Task<User> SetMediaMatadata(string blobName, Metadata metadata)
        {
            if (State == default)
                throw new UserNotFoundException();
            State.SetMediaMetadata(blobName, metadata);
            await WriteStateAsync();
            return State;
        }

        public async Task<User> SetMediaModerationResult(string blobName, ModerationResult moderationResult)
        {
            if (State == default)
                throw new UserNotFoundException();
            State.SetMediaModerationResult(blobName, moderationResult);
            await WriteStateAsync();
            return State;
        }

        public async Task<User> AddMediaThumbnail(string blobName, Thumbnail thumbnail)
        {
            if (State == default)
                throw new UserNotFoundException();
            State.AddMediaThumbnail(blobName, thumbnail);
            await WriteStateAsync();
            return State;
        }

        public async Task<User> UpdateUserName(UserName userName)
        {
            if (State == default)
                throw new UserNotFoundException();
            State.UpdateUserName(userName);
            await WriteStateAsync();
            return State;
        }
    }
}
