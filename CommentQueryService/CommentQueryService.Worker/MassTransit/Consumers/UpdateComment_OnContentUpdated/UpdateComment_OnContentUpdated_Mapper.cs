using CommentQueryService.Application.UseCases.UpdateComment;
using CommentQueryService.Domain;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnContentUpdated
{
    internal class UpdateComment_OnContentUpdated_Mapper
    {
        public Content Map(CommentContentUpdatedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpdateCommentRequest Map(CommentContentUpdatedEvent @event) =>
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
