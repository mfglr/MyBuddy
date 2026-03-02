using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.PostService;

namespace MediaService.Worker.Consumers.CreateMedia_OnPostCreated
{
    internal class Mapper
    {
        private CreateMediaRequest_Media Map(Guid ownerId, PostCreatedEvent_Media media) =>
            new(
                ownerId,
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Instruction
            );

        public CreateMediaRequest Map(PostCreatedEvent @event) =>
            new(@event.Media.Select(media => Map(@event.Id,media)));
    }
}
