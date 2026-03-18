using CommentQueryService.Shared.Model;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserNameUpdated
{
    internal class UpsertUserOn_UserNameUpdated_Mapper
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
