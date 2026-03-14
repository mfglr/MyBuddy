using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public UserMediaCreatedEvent_Media Map(Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails
            );
        public UserMediaCreatedEvent Map(User user, Media createdMedia) =>
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
                new(
                    user.Id,
                    createdMedia.ContainerName,
                    createdMedia.BlobName,
                    createdMedia.Type,
                    createdMedia.Instruction
                )
            );
    }
}
