using PostLikeQueryService.Application;
using System.Text.Json;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class PostLikeResponseMapper
    {
        public PostLikeResponse Map(InternalPostLikeResponse response) =>
            new(
                response.UserId,
                response.Name,
                response.UserName,
                response.Media != null ? JsonSerializer.Deserialize<PostLikeResponse_Media>(response.Media) : null,
                response.CreatedAt
            );
    }
}
