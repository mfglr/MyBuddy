using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountMediaCreated
{
    internal class UpdatePostUser_OnAccountMediaCreated_Mapper
    {
        public UpdatePostUserRequest Map(AccountMediaCreatedEvent @event) =>
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
