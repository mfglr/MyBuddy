using CommentQueryService.Shared.Model;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnUserCreated_Mapper
    {
        public User Map(UserCreatedEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
