using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_Mapper
    {
        public User Map(AccountUserNameUpdatedEvent @event) =>
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
