using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.PostService;

namespace MediaService.Worker.Consumers.CreateMedia_OnPostCreated
{
    internal class CreateMedia_OnPostCreated_Mapper
    {
        public CreateMediaRequest Map(PostCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Media
            );
    }
}
