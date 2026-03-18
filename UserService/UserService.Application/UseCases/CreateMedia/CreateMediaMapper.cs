using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public UserMediaCreatedEvent Map(User user, Media.Models.Media createdMedia) =>
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
                createdMedia
            );
    }
}
