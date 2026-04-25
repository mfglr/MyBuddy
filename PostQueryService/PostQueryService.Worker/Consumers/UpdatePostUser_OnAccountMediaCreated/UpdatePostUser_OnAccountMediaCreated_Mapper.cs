using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountMediaCreated
{
    internal class UpdatePostUser_OnAccountMediaCreated_Mapper
    {
        public UpdatePostUserRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public UpdatePostUserRequest Map(AccountMediaCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.UserName,
                @event.Name,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
