using Media.Models;

namespace CommentLikeQueryService.Domain
{
    public record UserMedia(ModerationResult? ModerationResult, IEnumerable<Thumbnail> Thumbnails);
}
