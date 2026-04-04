using PostLikeQueryService.Application.UseCases.UpsertUser;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_Mapper
    {
        public UpsertUserRequest Map(AccountMediaSetEvent @event) =>
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
