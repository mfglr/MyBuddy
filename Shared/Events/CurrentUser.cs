using Media.Models;

namespace Shared.Events
{
    public record CurrentUserMedia(
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    );

    public record CurrentUser(
        Guid Id,
        int Version,
        string UserName,
        string? Name,
        CurrentUserMedia? Media
    );
}
