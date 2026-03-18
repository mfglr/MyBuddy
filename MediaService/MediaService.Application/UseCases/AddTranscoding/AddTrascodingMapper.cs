using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.AddTranscoding
{
    internal class AddTrascodingMapper
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
