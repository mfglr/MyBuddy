using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases
{
    public record PostProjectionResponse(
        string UserId,
        string? Name,
        string UserName,
        Media.Models.MediaProcessingContext? ProfilePhoto,
        string Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        PostContent? Content,
        IEnumerable<Media.Models.MediaProcessingContext> Media
    );
}