using CommentQueryService.Shared.Model;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_Mapper
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
