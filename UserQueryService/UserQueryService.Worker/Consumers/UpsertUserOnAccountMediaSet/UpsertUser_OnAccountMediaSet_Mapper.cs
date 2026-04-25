using Shared.Events;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_Mapper
    {
        public UserMedia Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public User Map(AccountMediaSetEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Gender,
                @event.Media.Select(Map)
            );
    }
}
