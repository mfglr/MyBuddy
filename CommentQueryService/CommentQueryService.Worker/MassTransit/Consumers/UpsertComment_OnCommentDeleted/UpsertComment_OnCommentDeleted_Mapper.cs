using CommentQueryService.Application.UseCases.UpsertComment;
using CommentQueryService.Domain.CommentAggregate;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentDeleted
{
    internal class UpsertComment_OnCommentDeleted_Mapper
    {
        public UpsertCommentRequest_Content Map(CommentDeletedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpsertCommentRequest Map(CommentDeletedEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
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
