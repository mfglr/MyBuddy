using PostQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUserOn_AccountUserNameUpdated_Mapper
    {
        public User Map(AccountUserNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
