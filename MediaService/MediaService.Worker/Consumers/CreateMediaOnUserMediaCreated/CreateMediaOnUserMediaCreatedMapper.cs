using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.UserService;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMediaOnUserMediaCreatedMapper
    {
        private CreateMediaRequest_Media Map(UserMediaCreatedEvent_MediaCreated media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Instruction
            );
        public CreateMediaRequest Map(UserMediaCreatedEvent @event) =>
            new(
                @event.Id,
                [Map(@event.MediaCreated)]
            );
    }
}
