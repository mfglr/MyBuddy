namespace Shared.Events.CommentLikeService
{
    public record CommentLikedEvent(
        Guid CommentId,
        Guid UserId,
        Guid SequenceId,
        DateTime CreatedAt
    );
}
