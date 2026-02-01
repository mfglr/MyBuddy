using PostQueryService.Application.QueryRepositories;
using System.Text.Json;

namespace PostQueryService.Infrastructure.MsSql.QuerRepositories
{
    internal class PostResponseMapper
    {
        public PostResponse ToPostResponse(InternalPostResponse postResponse) =>
            new (
                postResponse.Id,
                postResponse.CreatedAt,
                postResponse.UpdatedAt,
                postResponse.Content != null
                     ? new PostResponse_Content(
                            postResponse.Content.Value,
                            postResponse.Content.ModerationResult
                        )
                     : null,
                JsonSerializer.Deserialize<IEnumerable<PostResponse_Media>>(postResponse.Media) ?? [],
                postResponse.UserId,
                postResponse.Name,
                postResponse.UserName,
                postResponse.ProfilePhoto != null
                    ? JsonSerializer.Deserialize<PostResponse_Media>(postResponse.ProfilePhoto)
                    : null
            );
    }
}
