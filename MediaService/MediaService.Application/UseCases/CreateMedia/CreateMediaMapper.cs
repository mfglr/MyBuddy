using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public IEnumerable<MediaCreatedEvent> Map(MediaList mediaList) =>
            mediaList.Items
            .Select(
                media => new MediaCreatedEvent(
                    mediaList.Id.Id,
                    mediaList.Id.ContainerName,
                    media.BlobName,
                    media.Type,
                    media.Instruction
                )
            );
    }
}
