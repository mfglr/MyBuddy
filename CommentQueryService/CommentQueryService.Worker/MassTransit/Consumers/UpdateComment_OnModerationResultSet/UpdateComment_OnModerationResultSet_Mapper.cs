using CommentQueryService.Application.UseCases.UpdateComment;
using CommentQueryService.Domain;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnModerationResultSet
{
    internal class UpdateComment_OnModerationResultSet_Mapper
    {
        public Content Map(CommentContentModerationResultSetEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpdateCommentRequest Map(CommentContentModerationResultSetEvent @event) =>
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
