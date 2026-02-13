namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal record InternalPostLikeResponse(
        Guid UserId,
        string? Name,
        string UserName,
        string? Media,
        DateTime CreatedAt
    );
}
