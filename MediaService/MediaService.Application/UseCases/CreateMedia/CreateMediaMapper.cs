using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public MediaCreatedEvent Map(Guid id, Media media) =>
            new(
                id,
                media.Id.ContainerName,
                media.Id.BlobName,
                media.Type,
                media.Instruction
            );
    }
}
