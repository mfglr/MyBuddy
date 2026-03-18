using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserNameUpdated
{
    internal class UpsertUser_OnUserNameUpdated_Mapper
    {
        public User Map(UserNameUpdatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
