using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.SetThumbnails
{
    internal class SetThumbnailsMapper
    {
        public MediaPreprecessingCompletedEvent Map(Media media) =>
            new(
                media.OwnerId,
                media.Id.ContainerName,
                media.Id.BlobName,
                media.Metadata,
                media.ModerationResult,
                media.TranscodedBlobName,
                media.Thumbnails,
                media.Instruction
            );
    }
}
