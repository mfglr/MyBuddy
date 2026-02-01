using Shared.Events;

namespace UserQueryService.Application.UseCases.GetById
{
    public record GetByIdResponse_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        bool IsDeleted,
        bool IsActive
    );
    public record GetByIdResponse(
        string Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<GetByIdResponse_Media> Media
    );
}
