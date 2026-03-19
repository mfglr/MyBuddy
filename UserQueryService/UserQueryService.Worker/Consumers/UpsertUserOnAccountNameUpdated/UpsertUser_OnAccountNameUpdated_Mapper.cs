using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountNameUpdated
{
    internal class UpsertUser_OnAccountNameUpdated_Mapper
    {
        public User Map(AccountNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Gender,
                @event.Media
            );
    }
}
