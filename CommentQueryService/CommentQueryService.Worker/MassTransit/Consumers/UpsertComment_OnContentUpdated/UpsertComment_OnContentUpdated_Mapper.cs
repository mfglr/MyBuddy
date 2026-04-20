using CommentQueryService.Application.UseCases.UpsertComment;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnContentUpdated
{
    internal class UpsertComment_OnContentUpdated_Mapper
    {
        public UpsertCommentRequest_Content Map(CommentContentUpdatedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpsertCommentRequest Map(CommentContentUpdatedEvent @event) =>
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
