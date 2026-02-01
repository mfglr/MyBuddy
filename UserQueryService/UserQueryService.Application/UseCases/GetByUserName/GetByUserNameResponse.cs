using Shared.Events;

namespace UserQueryService.Application.UseCases.GetByUserName
{
    public record GetByUserNameResponse_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        bool IsDeleted,
        bool IsActive
    );
    public record GetByUserNameResponse(
        string Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<GetByUserNameResponse_Media> Media
    );
}
