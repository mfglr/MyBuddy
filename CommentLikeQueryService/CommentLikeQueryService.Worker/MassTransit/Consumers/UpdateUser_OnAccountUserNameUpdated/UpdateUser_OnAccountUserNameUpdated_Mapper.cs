using CommentLikeQueryService.Application.UseCases.UpdateUser;
using CommentLikeQueryService.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountUserNameUpdated
{
    internal class UpdateUser_OnAccountUserNameUpdated_Mapper
    {
        public UserMedia Map(MediaMessage media) =>
            new(
                media.Context.ModerationResult,
                media.Context.Thumbnails
            );

        public UpdateUserRequest Map(AccountUserNameUpdatedEvent @event) =>
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
