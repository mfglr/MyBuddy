namespace UserQueryService.Infrastructure
{
    internal record ElasticSearchOptions(
        string Host,
        string UserName,
        string Password,
        string IndexName
    );
}
