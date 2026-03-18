using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameMapper
    {
        public UserNameUpdatedEvent Map(User user) =>
            new(
                user.Id,
                user.CreatedAt,
                user.UpdatedAt,
                user.Version,
                user.IsDeleted,
                user.Name?.Value,
                user.UserName.Value,
                user.Gender.Value,
                user.Media
            );
    }
}
