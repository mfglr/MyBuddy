using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaMapper
    {
        public UserMediaDeletedEvent_Media Map(Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails
            );

        public UserMediaDeletedEvent Map(User user, Media mediaDeleted) =>
            new(
                user.Id,
                user.CreatedAt,
                user.UpdatedAt,
                user.Version,
                user.IsDeleted,
                user.Name?.Value,
                user.UserName.Value,
                user.Gender.Value,
                user.Media.Select(Map),
                new UserMediaDeletedEvent_MediaDeleted(
                    mediaDeleted.ContainerName,
                    mediaDeleted.BlobName
                ),
                user.IsValidVersion
            );
    }
}