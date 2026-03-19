using CommentQueryService.Shared.Model;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_Mapper
    {
        public User Map(AccountMediaSetEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
