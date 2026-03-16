using CommentQueryService.Shared.Model;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserCreated
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
                []
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
