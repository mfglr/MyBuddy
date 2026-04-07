using CommentQueryService.Application.UseCases.UpdateUser;
using CommentQueryService.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaCreated
{
    internal class UpdateUser_OnAccountMediaCreated_Mapper
    {
        private UserMedia Map(MediaMessage media) =>
            new(
                media.Context.ModerationResult,
                media.Context.Thumbnails
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
