using CommentQueryService.Domain;
using CommentQueryService.Domain.UserAggregate;

namespace CommentQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper
    {
        public CommentMedia Map(UpsertUserRequest_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings
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
