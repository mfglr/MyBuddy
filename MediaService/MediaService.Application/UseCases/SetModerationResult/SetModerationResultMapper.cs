using MediaService.Domain;
using Shared.Events.MediaService;
namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResultMapper
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
