using CommentQueryService.Shared.Model;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentCreated
{
    internal class UpsertComment_OnCommentCreated_Mapper
    {
        public Content Map(CommentCreatedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public Comment Map(CommentCreatedEvent @event) =>
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
