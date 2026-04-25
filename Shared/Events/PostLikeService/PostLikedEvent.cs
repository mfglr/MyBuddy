namespace Shared.Events.PostLikeService
{
    public record PostLikedEvent(
        Guid UserId,
        Guid PostId,
        Guid SequenceId,
        DateTime CreatedAt
    );
}
