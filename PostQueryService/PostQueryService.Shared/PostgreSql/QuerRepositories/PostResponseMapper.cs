using PostQueryService.Shared.Model;
using System.Text.Json;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal class PostResponseMapper
    {
        public PostResponse ToPostResponse(InternalPostResponse postResponse) =>
            new (
                postResponse.UserId,
                postResponse.UserName,
                postResponse.Name,
                postResponse.ProfilePhoto != null
                    ? JsonSerializer.Deserialize<Media>(postResponse.ProfilePhoto)
                    : null,
                postResponse.Id,
                postResponse.CreatedAt,
                postResponse.UpdatedAt,
                postResponse.Content,
                JsonSerializer.Deserialize<IEnumerable<Media>>(postResponse.Media) ?? [],
                postResponse.LikeCount,
                postResponse.CommentCount
            );
    }
}
