using CommentQueryService.Application.UseCases.UpdateUser;
using CommentQueryService.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_Mapper
    {
        private UserMedia Map(MediaMessage media) =>
            new(
                media.Context.ModerationResult,
                media.Context.Thumbnails
            );
        
        public UpdateUserRequest Map(AccountMediaSetEvent @event) =>
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
