namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal record ElasticSearchOptions(
        string Host,
        string PostIndexName,
        string UserIndexName,
        string UserName,
        string Password
    );
}
