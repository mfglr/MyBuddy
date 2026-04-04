using PostQueryService.Domain;

namespace PostQueryService.Application.UseCases
{
    internal class MediaMapper
    {
        public PostQueryMedia Map(Media.Models.Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings
            );
    }
}
