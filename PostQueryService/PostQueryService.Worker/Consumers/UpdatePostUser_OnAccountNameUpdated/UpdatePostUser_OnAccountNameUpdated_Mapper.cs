using PostQueryService.Application.UseCases.UpdatePostUser;
using Shared.Events;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountNameUpdated
{
    internal class UpdatePostUser_OnAccountNameUpdated_Mapper
    {
        public UpdatePostUserRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public UpdatePostUserRequest Map(AccountNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.DeletedAt,
                @event.Version,
                @event.UserName,
                @event.Name,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
