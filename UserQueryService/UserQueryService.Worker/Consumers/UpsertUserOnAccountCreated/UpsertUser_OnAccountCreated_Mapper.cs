using Shared.Events;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_Mapper
    {
        public UserMedia Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );


        public User Map(AccountCreatedEvent @event) =>
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
