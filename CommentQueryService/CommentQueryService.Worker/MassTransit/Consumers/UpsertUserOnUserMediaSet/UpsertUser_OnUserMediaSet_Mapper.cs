using CommentQueryService.Shared.Model;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserMediaSet
{
    internal class UpsertUser_OnUserMediaSet_Mapper
    {
        public User Map(UserMediaSetEvent @event) =>
            new(
                @event.Id,
                @event.Version,
                @event.Name,
                @event.UserName,
                @event.Media.FirstOrDefault()
            );
    }
}
