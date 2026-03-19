using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.Account;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMedia_OnUserMediaCreated_Mapper
    {
        public CreateMediaRequest Map(AccountCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Media
            );
    }
}
