using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUser_OnAccountMediaCreated
{
    internal class UpsertUser_OnAccountMediaCreated_Mapper
    {
        public UpsertUserRequest Map(AccountMediaCreatedEvent @event) =>
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
