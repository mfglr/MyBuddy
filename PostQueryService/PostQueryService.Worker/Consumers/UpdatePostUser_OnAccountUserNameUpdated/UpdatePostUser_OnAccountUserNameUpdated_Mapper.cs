using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountUserNameUpdated
{
    internal class UpdatePostUser_OnAccountUserNameUpdated_Mapper
    {
        public UpdatePostUserRequest Map(AccountUserNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.DeletedAt,
                @event.Version,
                @event.UserName,
                @event.Name,
                @event.Media.FirstOrDefault()
            );
    }
}
