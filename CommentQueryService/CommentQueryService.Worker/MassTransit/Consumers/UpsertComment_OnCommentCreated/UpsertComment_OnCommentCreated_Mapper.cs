using CommentQueryService.Application.UseCases.UpsertComment;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentCreated
{
    internal class UpsertComment_OnCommentCreated_Mapper
    {
        private UpsertCommentRequest_Content Map(CommentCreatedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpsertCommentRequest Map(CommentCreatedEvent @event) =>
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
