namespace PostQueryService.Domain.PostProjectionAggregate
{
    public record Post(
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        int Version,
        PostContent? Content,
        IEnumerable<PostQueryMedia> Media
    );
}
