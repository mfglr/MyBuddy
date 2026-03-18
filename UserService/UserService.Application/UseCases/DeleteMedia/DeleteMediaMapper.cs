using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaMapper
    {
        public UserMediaDeletedEvent Map(User user, Media.Models.Media mediaDeleted) =>
            new(
                user.Id,
                user.CreatedAt,
                user.UpdatedAt,
                user.Version,
                user.IsDeleted,
                user.Name?.Value,
                user.UserName.Value,
                user.Gender.Value,
                user.Media,
                mediaDeleted
            );
    }
}