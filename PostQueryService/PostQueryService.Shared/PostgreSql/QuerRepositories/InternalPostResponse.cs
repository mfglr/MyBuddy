using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal record InternalPostResponse(
        Guid UserId,
        string? Name,
        string UserName,
        string? ProfilePhoto,
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Content? Content,
        string Media,
        int LikeCount,
        int CommentCount
    );
}
