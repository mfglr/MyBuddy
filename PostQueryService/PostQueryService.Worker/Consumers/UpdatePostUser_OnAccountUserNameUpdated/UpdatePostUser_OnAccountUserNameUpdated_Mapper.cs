using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountUserNameUpdated
{
    internal class UpdatePostUser_OnAccountUserNameUpdated_Mapper
    {
        public UpdatePostUserRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public UpdatePostUserRequest Map(AccountUserNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.UserName,
                @event.Name,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
