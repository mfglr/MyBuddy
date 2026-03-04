using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    internal class SetTranscodedBlobNameMapper
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
