namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal record ElasticSearchVersion(long? PrimaryTerm, long? SequenceNumber);
}
