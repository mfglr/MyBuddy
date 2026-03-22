using Media.Models;

namespace CommentQueryService.Domain
{
    public record UserMedia(ModerationResult? ModerationResult, IEnumerable<Thumbnail> Thumbnails);
}
