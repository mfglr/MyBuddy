using CommentQueryService.Shared.Model;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentDeleted
{
    internal class UpsertComment_OnCommentDeleted_Mapper
    {
        public Content Map(CommentDeletedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public Comment Map(CommentDeletedEvent @event) =>
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
