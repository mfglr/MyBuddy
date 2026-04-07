using Shared.Events;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountGenderUpdated
{
    internal class UpsertUser_OnAccountGenderUpdated_Mapper
    {
        public UserMedia Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public User Map(AccountGenderUpdatedEvent @event) =>
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
