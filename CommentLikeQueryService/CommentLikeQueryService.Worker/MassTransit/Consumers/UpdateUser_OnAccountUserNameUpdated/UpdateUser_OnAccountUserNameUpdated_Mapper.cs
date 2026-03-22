using CommentLikeQueryService.Application.UseCases.UpdateUser;
using CommentLikeQueryService.Domain;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountUserNameUpdated
{
    internal class UpdateUser_OnAccountUserNameUpdated_Mapper
    {
        public UserMedia Map(Media.Models.Media media) =>
            new(
                media.ModerationResult,
                media.Thumbnails
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
