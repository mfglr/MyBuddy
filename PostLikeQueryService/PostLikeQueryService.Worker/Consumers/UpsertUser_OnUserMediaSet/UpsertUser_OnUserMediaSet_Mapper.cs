using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserMediaSet
{
    internal class UpsertUser_OnUserMediaSet_Mapper
    {
        public Media Map(UserMediaSetEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                []
            );

        public User Map(UserMediaSetEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.Select(Map).FirstOrDefault()
            );
    }
}
