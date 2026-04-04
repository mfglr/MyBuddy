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

        private PostQueryMedia Map(Media.Models.Media media) =>
            new(
                media.BlobName,
                media.ContainerName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings
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
                request.Id,
                request.UserId,
                MapPost(request),
                Map(user)
            );
    }
}
