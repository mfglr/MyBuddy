using MediaService.Domain;
using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public MediaPreprocessingCompletedEvent Map(Media media) =>
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
