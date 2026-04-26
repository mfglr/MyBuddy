using PostQueryService.Domain;
using PostQueryService.Domain.PostProjectionAggregate;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    internal class UpsertPostMapper
    {
        public PostContent Map(UpsertPostRequest_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public PostQueryMedia Map(UpsertPostRequest_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context.Type,
                media.Context.Metadata,
                media.Context.ModerationResult,
                media.Context.Thumbnails,
                media.Context.Transcodings
            );

        public PostProjectionUser Map(User user) =>
            new(
                user.Version,
                user.Name,
                user.UserName,
                user.Media
            );

        public PostProjection Map(UpsertPostRequest request, User user) =>
            new(
                request.Id.ToString(),
                request.UserId.ToString(),
                request.CreatedAt,
                request.UpdatedAt,
                request.IsDeleted,
                request.Version,
                request.Content != null ? Map(request.Content) : null,
                [..request.Media.Select(Map)],
                Map(user)
            );
    }
}
