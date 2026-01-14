using Shared.Objects;

namespace PostService.Application.UseCases.SetPostContentModerationResult
{
    public record SetPostContentModerationResultResponse_Content(string Value, ModerationResult ModerationResult);
    public record SetPostContentModerationResultResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        bool IsDeleted,
        int Version,
        SetPostContentModerationResultResponse_Content Content,
        IReadOnlyList<Media> Media
    );
}
