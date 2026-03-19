using PostQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUserOnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_Mapper
    {
        public User Map(AccountCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
