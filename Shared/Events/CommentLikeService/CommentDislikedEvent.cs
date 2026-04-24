namespace Shared.Events.CommentLikeService
{
    public record CommentDislikedEvent(
        Guid CommentId,
        Guid UserId,
        Guid SequenceId,
        DateTime CreatedAt
    );
}
