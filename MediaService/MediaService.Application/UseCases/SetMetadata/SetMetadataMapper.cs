using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataMapper
    {
        public MediaPreprecessingCompletedEvent Map(MediaList mediaList) =>
            new(
                mediaList.Id.Id,
                mediaList.Id.ContainerName,
                mediaList.Items.Select(
                    media => new MediaPreprecessingCompletedEvent_Media(
                        media.BlobName,
                        media.Metadata,
                        media.ModerationResult,
                        media.TranscodedBlobName,
                        media.Thumbnails,
                        media.Instruction
                    )
                )
            );
    }
}
