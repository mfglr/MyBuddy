using PostQueryService.Domain;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases.GetByUserId
{
    internal class GetByUserIdMapper
    {
        public PostProjectionResponse_Content Map(PostContent content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public PostProjectionResponse_Media Map(PostQueryMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata!,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings
            );

        public PostProjectionResponse Map(PostProjection post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.Content != null ? Map(post.Content) : null,
                post.Media.Select(Map),
                post.UserId,
                post.User.Name,
                post.User.UserName,
                post.User.Media != null ? Map(post.User.Media) : null
            );
    }
}
