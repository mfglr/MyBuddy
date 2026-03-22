using CommentQueryService.Application.UseCases.UpdateComment;
using CommentQueryService.Domain;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentDeleted
{
    internal class UpdateComment_OnCommentDeleted_Mapper
    {
        public Content Map(CommentDeletedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpdateCommentRequest Map(CommentDeletedEvent @event) =>
            new(
                @event.Id,
                new(
                    @event.CreatedAt,
                    @event.UpdatedAt,
                    @event.DeletedAt,
                    @event.IsDeleted,
                    @event.Version,
                    @event.UserId,
                    @event.PostId,
                    @event.ParentId,
                    Map(@event.Content)
                )
            );
    }
}
