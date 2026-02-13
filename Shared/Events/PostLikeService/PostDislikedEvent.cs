namespace Shared.Events.PostLikeService
{
    public record PostDislikedEvent(Guid UserId, Guid PostId, DateTime CreatedAt, int Version, bool IsDeleted);
}
