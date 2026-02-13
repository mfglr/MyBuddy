using MediatR;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Application.UseCases.UpgradeUser
{
    public record UpgradeUserRequest_Media(
        string ContainerName,
        string BlobName,
        Metadata Metadata,
        ModerationResult ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    );
    public record UpgradeUserRequest(
        Guid Id,
        int Version,
        bool IsDeleted,
        string? Name,
        string UserName,
        UpgradeUserRequest_Media? Media
    ) : IRequest;
}
