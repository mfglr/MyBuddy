namespace CommentQueryService.Domain.CommentAggregate
{
    public record CommentUser(
        int Version,
        string? Name,
        string UserName,
        CommentMedia? Media
    );
}
