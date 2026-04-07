using MediaService.Application.UseCases.CreateMedia;
using Shared.Events;
using Shared.Events.Account;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMedia_OnUserMediaCreated_Mapper
    {
        public CreateMediaRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public CreateMediaRequest Map(AccountCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Media.Select(Map)
            );
    }
}
