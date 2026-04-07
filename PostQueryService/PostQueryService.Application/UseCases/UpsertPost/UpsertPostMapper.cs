using PostQueryService.Domain;
using PostQueryService.Domain.PostProjectionAggregate;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    internal class UpsertPostMapper
    {
        private PostContent Map(UpsertPostRequest_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        private PostQueryMedia Map(UpsertPostRequest_Media media) =>
            new(
                media.BlobName,
                media.ContainerName,
                media.Context.Type,
                media.Context.Metadata,
                media.Context.ModerationResult,
                media.Context.Thumbnails,
                media.Context.Transcodings
            );

        public Post MapPost(UpsertPostRequest request) =>
            new(
                request.CreatedAt,
                request.UpdatedAt,
                request.DeletedAt,
                request.Version,
                request.Content is not null ? Map(request.Content) : null,
                request.Media.Select(Map)
            );

        private PostProjectionUser Map(User user) =>
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
                MapPost(request),
                Map(user)
            );
    }
}
