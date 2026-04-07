using Media.Models;

namespace PostService.Domain
{
    public record PostMedia(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    )
    {

        public PostMedia Set(MediaProcessingContext context) =>
            new(
                ContainerName,
                BlobName,
                context
            );
    }
}
