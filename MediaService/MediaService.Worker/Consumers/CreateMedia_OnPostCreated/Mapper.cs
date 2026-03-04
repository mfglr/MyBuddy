using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.PostService;

namespace MediaService.Worker.Consumers.CreateMedia_OnPostCreated
{
    internal class Mapper
    {
        private CreateMediaRequest_Media Map(PostCreatedEvent_Media media) =>
            new(
                media.BlobName,
                media.Type,
                media.Instruction
            );

        public CreateMediaRequest Map(PostCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Media.First().ContainerName,
                @event.Media.Select(Map)
            );
    }
}
