using Shared.Events;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_Mapper
    {
        public UserMedia Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public User Map(AccountUserNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.DeletedAt,
                @event.IsDeleted,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Gender,
                @event.Media.Select(Map)
            );
    }
}
