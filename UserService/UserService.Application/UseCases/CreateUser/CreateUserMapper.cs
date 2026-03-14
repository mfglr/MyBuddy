using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateUser
{
    public class CreateUserMapper
    {
        public UserCreatedEvent_Media Map(Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails
            );

        public UserCreatedEvent Map(User user) =>
            new(
                user.Id,
                user.CreatedAt,
                user.UpdatedAt,
                user.Version,
                user.IsDeleted,
                user.Name?.Value,
                user.UserName.Value,
                user.Gender.Value,
                user.Media.Select(Map)
            );
    }
}
