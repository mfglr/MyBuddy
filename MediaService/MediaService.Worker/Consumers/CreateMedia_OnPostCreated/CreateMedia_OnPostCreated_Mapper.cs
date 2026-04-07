using MediaService.Application.UseCases.CreateMedia;
using Shared.Events;
using Shared.Events.PostService;

namespace MediaService.Worker.Consumers.CreateMedia_OnPostCreated
{
    internal class CreateMedia_OnPostCreated_Mapper
    {
        public CreateMediaRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public CreateMediaRequest Map(PostCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Media.Select(Map)
            );
    }
}
