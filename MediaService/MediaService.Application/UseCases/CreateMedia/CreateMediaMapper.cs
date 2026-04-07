using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
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
