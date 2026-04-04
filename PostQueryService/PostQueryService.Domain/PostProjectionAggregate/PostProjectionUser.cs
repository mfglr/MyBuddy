namespace PostQueryService.Domain.PostProjectionAggregate
{
    public record PostProjectionUser(
        int Version,
        string? Name,
        string UserName,
        PostQueryMedia? Media
    );
}
