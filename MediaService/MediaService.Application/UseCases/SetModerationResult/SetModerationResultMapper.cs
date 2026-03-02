using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultMapper
    {
        public MediaPreprecessingCompletedEvent Map(Media media) =>
            new(
                media.OwnerId,
                media.ContainerName,
                media.BlobName,
                media.Metadata,
                media.ModerationResult,
                media.TranscodedBlobName,
                media.Thumbnails,
                media.Instruction
            );
    }
}
