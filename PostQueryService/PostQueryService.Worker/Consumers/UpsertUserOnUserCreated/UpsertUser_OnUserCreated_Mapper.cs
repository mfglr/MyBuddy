using PostQueryService.Shared.Model;
using Shared.Events.UserService;
using System.Text.Json;

namespace PostQueryService.Worker.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnUserCreated_Mapper
    {
        public Media Map(UserCreatedEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                null
            );

        public User Map(UserCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault() != null
                    ? Map(@event.Media.First())
                    : null
            );
    }
}
