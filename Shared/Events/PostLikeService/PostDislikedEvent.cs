namespace Shared.Events.PostLikeService
{
    public record PostDislikedEvent(
        Guid UserId,
        Guid PostId,
        Guid SequenceId,
        DateTime CreatedAt,
        int Version,
        bool IsDeleted,
        DateTime? DeletedAt
    );
}
