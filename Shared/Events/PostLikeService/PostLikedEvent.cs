namespace Shared.Events.PostLikeService
{
    public record PostLikedEvent(Guid UserId, Guid PostId, DateTime CreatedAt, int Version, bool IsDeleted);
}
