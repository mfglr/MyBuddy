namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal record Version(long? PrimaryTerm, long? SeqNo);
}
