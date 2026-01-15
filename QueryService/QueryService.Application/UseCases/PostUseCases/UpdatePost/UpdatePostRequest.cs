using Shared.Objects;

namespace QueryService.Application.UseCases.PostUseCases.UpdatePost
{
    public record UpdatePostRequest_Content(string Value, ModerationResult ModerationResult);
    public record UpdatePostRequest(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        bool IsDeleted,
        int Version,
        UpdatePostRequest_Content? Content,
        List<Media> Media
    )
    {
        public bool IsValidVersion => !Media.Any(x => x.ModerationResult == null);
    }
}
