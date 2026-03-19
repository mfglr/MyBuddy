using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountGenderUpdated
{
    internal class UpsertUser_OnAccountGenderUpdated_Mapper
    {
        public User Map(AccountGenderUpdatedEvent @event) =>
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
