using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.Account;

namespace MediaService.Worker.Consumers.CreateMedia_OnAccountMediaCreated
{
    internal class CreateMedia_OnAccountMediaCreated_Mapper
    {
        public CreateMediaRequest Map(AccountMediaCreatedEvent @event) =>
            new(
                @event.Id,
                [@event.MediaCreated]
            );
    }
}
