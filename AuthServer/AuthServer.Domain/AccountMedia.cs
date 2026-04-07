using Media.Models;

namespace AuthServer.Domain
{
    public record AccountMedia(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    )
    {
        public AccountMedia Set(MediaProcessingContext context) =>
            new(
                ContainerName,
                BlobName,
                context
            );
    }
}
