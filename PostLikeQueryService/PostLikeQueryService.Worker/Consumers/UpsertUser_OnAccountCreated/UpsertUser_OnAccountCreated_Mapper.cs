using PostLikeQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountCreated
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
