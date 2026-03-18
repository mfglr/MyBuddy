using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_Mapper
    {
        public User Map(NameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
