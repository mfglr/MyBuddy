namespace Shared.Events.CommentLikeService
{
    public record CommentLikeCreatedEvent(
        Guid CommentId,
        Guid UserId,
        Guid SequenceId,
        DateTime CreatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version
    );
}
