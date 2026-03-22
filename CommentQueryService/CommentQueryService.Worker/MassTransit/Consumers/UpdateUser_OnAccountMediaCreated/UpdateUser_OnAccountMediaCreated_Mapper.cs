using CommentQueryService.Application.UseCases.UpdateUser;
using CommentQueryService.Domain;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaCreated
{
    internal class UpdateUser_OnAccountMediaCreated_Mapper
    {
        private UserMedia Map(Media.Models.Media media) =>
            new(
                media.ModerationResult,
                media.Thumbnails
            );

        public UpdateUserRequest Map(AccountMediaCreatedEvent @event) =>
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
