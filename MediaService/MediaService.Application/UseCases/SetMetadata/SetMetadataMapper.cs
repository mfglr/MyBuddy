using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadataMapper
    {
        public MediaPreprocessingCompletedEvent Map(Domain.Media media) =>
            new(
                media.OwnerId,
                media.ContainerName,
                media.BlobName,
                media.Context
            );
    }
}
