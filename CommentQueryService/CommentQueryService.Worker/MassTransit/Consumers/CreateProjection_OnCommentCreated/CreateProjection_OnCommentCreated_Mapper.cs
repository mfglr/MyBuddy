using CommentQueryService.Application.UseCases.CreateProjection;
using CommentQueryService.Domain;
using Shared.Events;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.CreateProjection_OnCommentCreated
{
    internal class CreateProjection_OnCommentCreated_Mapper
    {
        private Content Map(CommentCreatedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        private UserMedia Map(CurrentUserMedia media) =>
            new(
                media.ModerationResult,
                media.Thumbnails
            );

        private User Map(CurrentUser user) =>
            new(
                user.Id,
                user.Version,
                user.Name,
                user.UserName,
                user.Media != null ? Map(user.Media) : null
            );

        public CreateProjectionRequest Map(CommentCreatedEvent @event) =>
            new(
                @event.Id,
                new(
                    @event.CreatedAt,
                    @event.UpdatedAt,
                    @event.DeletedAt,
                    @event.IsDeleted,
                    @event.Version,
                    @event.PostId,
                    @event.ParentId,
                    @event.RepliedId,
                    Map(@event.Content)
                ),
                Map(@event.User)
            );
    }
}
