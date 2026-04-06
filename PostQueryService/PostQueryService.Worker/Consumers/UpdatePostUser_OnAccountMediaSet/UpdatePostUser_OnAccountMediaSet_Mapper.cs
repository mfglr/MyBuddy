using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountMediaSet
{
    internal class UpdatePostUser_OnAccountMediaSet_Mapper
    {
        public UpdatePostUserRequest Map(AccountMediaSetEvent @event) =>
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
