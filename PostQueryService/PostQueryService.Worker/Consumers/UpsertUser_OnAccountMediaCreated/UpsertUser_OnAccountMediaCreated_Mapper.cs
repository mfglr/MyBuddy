using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUser_OnAccountMediaCreated
{
    internal class UpsertUser_OnAccountMediaCreated_Mapper
    {
        public UpsertUserRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public UpsertUserRequest Map(AccountMediaCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
