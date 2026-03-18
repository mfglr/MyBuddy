using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.AddThumbnail
{
    internal class AddThumbnailMapper
    {
        public MediaPreprocessingCompletedEvent Map(Domain.Media media) =>
            new(
                media.OwnerId,
                media.ContainerName,
                media.BlobName,
                media.Metadata,
                media.ModerationResult,
                media.Transcodings,
                media.Thumbnails,
                media.Instruction
            );
    }
}
