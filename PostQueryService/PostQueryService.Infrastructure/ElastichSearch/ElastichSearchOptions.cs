namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal record ElasticSearchOptions(
        string Host,
        string IndexName
    );
}
