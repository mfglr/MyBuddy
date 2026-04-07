using CommentLikeQueryService.Application.UseCases.UpdateUser;
using CommentLikeQueryService.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountNameUpdated
{
    internal class UpdateUser_OnAccountNameUpdated_Mapper
    {
        public UserMedia Map(MediaMessage media) =>
            new(
                media.Context.ModerationResult,
                media.Context.Thumbnails
            );

        public UpdateUserRequest Map(AccountNameUpdatedEvent @event) =>
            new(
                new(
                    @event.Id,
                    @event.Version,
                    @event.Name,
                    @event.UserName,
                    @event.Media.Select(Map).FirstOrDefault()
                )
            );
    }
}
