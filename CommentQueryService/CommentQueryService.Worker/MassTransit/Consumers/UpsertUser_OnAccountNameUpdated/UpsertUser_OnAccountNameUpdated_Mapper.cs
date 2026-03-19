using CommentQueryService.Shared.Model;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountNameUpdated
{
    internal class UpsertUser_OnAccountNameUpdated_Mapper
    {
        public User Map(AccountNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
