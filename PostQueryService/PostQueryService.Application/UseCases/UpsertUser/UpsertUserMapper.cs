using PostQueryService.Domain;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper
    {
        public PostQueryMedia Map(UpsertUserRequest_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context.Type,
                media.Context.Metadata,
                media.Context.ModerationResult,
                media.Context.Thumbnails,
                media.Context.Transcodings
            );

        public User Map(UpsertUserRequest request) =>
            new(
                request.Id,
                request.Version,
                request.Name,
                request.UserName,
                request.Media != null ? Map(request.Media) : null
            );
    }
}
