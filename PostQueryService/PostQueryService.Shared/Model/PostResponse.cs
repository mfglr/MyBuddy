namespace PostQueryService.Shared.Model
{
    public record PostResponse(
        Guid UserId,
        string UserName,
        string? Name,
        Media? ProfilePhoto,
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Content? Content,
        IEnumerable<Media> Media,
        int LikeCount,
        int CommentCount
    );
}
