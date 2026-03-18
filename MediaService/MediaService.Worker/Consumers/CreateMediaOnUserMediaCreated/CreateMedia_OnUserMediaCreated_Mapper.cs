using MediaService.Application.UseCases.CreateMedia;
using Shared.Events.UserService;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMedia_OnUserMediaCreated_Mapper
    {
        public CreateMediaRequest Map(UserMediaCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Media
            );
    }
}
