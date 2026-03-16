namespace Shared.Events.CommentLikeService
{
    public record CommentLikedEvent(
        Guid CommentId,
        Guid UserId,
        Guid SequenceId,
        DateTime CreatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version
    );
}
