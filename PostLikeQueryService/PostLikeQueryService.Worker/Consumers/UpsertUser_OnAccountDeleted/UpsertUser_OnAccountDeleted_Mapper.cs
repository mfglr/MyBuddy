using PostLikeQueryService.Application.UseCases.UpsertUser;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountDeleted
{
    internal class UpsertUser_OnAccountDeleted_Mapper
    {
        public UpsertUserRequest Map(AccountDeletedEvent @event) =>
            new(
                @event.Id,
                @event.DeletedAt,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
