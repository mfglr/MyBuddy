using CommentLikeQueryService.Application.UseCases.CreateProjection;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.CreateProjection_OnCommentLikeCreated
{
    internal class CreateProjection_OnCommentCreated_Mapper
    {
        public CreateProjectionRequest Map(CommentLikeCreatedEvent @event) =>
            new(
                new(
                    @event.CommentId,
                    @event.SequenceId
                ),
                new(
                    @event.CreatedAt,
                    @event.DeletedAt,
                    @event.IsDeleted,
                    @event.Version
                ),
                new(
                    @event.UserId,
                    @event.CurrentUser.Version,
                    @event.CurrentUser.Name,
                    @event.CurrentUser.UserName,
                    @event.CurrentUser.Media != null
                    ? new(
                            @event.CurrentUser.Media.ModerationResult,
                            @event.CurrentUser.Media.Thumbnails
                    )
                    : null
                )
            );

    }
}
