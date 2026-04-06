using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountNameUpdated
{
    internal class UpdatePostUser_OnAccountNameUpdated_Mapper
    {
        public UpdatePostUserRequest Map(AccountNameUpdatedEvent @event) =>
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
