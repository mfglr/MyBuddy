using CommentQueryService.Shared.Model;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnModerationResultSet
{
    internal class UpsertComment_OnModerationResultSet_Mapper
    {
        public Content Map(CommentContentModerationResultSetEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public Comment Map(CommentContentModerationResultSetEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.DeletedAt,
                @event.IsDeleted,
                @event.Version,
                @event.UserId,
                @event.PostId,
                @event.ParentId,
                @event.RepliedId,
                Map(@event.Content)
            );
    }
}
