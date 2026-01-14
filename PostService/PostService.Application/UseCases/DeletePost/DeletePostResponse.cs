using Shared.Objects;

namespace PostService.Application.UseCases.DeletePost
{
    public record DeletePostResponse_Content(string Value, ModerationResult ModerationResult);
    public record DeletePostResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        bool IsDeleted,
        int Version,
        DeletePostResponse_Content Content,
        IReadOnlyList<Media> Media
    );
}
