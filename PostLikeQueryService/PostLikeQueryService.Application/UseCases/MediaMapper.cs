using PostLikeQueryService.Domain;

namespace PostLikeQueryService.Application.UseCases
{
    internal class MediaMapper
    {
        public PostLikeQueryMedia Map(Media.Models.Media media) =>
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
