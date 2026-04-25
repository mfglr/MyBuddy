using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUser_OnAccountNameUpdated
{
    internal class UpsertUser_OnAccountNameUpdated_Mapper
    {
        public UpsertUserRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public UpsertUserRequest Map(AccountNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
