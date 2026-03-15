using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_Mapper
    {
        public Media Map(NameUpdatedEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                []
            );

        public User Map(NameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
