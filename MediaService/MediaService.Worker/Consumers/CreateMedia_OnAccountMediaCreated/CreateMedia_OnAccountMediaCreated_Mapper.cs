using MediaService.Application.UseCases.CreateMedia;
using Shared.Events;
using Shared.Events.Account;

namespace MediaService.Worker.Consumers.CreateMedia_OnAccountMediaCreated
{
    internal class CreateMedia_OnAccountMediaCreated_Mapper
    {
        public CreateMediaRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public CreateMediaRequest Map(AccountMediaCreatedEvent @event) =>
            new(
                @event.Id,
                [Map(@event.MediaCreated)]
            );
    }
}
