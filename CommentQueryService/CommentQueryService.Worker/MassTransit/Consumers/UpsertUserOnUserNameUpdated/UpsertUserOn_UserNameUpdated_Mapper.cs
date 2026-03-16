using CommentQueryService.Shared.Model;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserNameUpdated
{
    internal class UpsertUserOn_UserNameUpdated_Mapper
    {
        public Media Map(UserNameUpdatedEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                []
            );

        public User Map(UserNameUpdatedEvent @event) =>
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
