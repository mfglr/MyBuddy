using Media.Models;

namespace PostService.Domain
{
    public record PostMedia(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    )
    {

        public IEnumerable<string> BlobNames => [BlobName, .. Context.BlobNames];

        public PostMedia Set(MediaProcessingContext context) =>
            new(
                ContainerName,
                BlobName,
                context
            );
    }
}
