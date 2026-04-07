using Media.Models;

namespace UserQueryService.Shared.Model
{
    public record UserMedia(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );
}
