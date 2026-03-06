using PostQueryService.Shared.Model;
using Shared.Events.UserService;
using System.Text.Json;

namespace PostQueryService.Worker.Consumers.UpsertUserOnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_Mapper
    {
        private Media Map(NameUpdatedEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                null
            );

        public User Map(NameUpdatedEvent @event) =>
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
