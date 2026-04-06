using Elastic.Clients.Elasticsearch;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal static class PaginationExtention
    {
        public static SearchRequestDescriptor<PostProjection> ToPage(
            this SearchRequestDescriptor<PostProjection> query,
            string? cursor,
            int pageSize
        ) =>
            cursor != null
                ? query
                    .Sort(s => s.Field(x => x.Id, SortOrder.Desc))
                    .SearchAfter(cursor)
                    .Size(pageSize)
                : query
                    .Sort(s => s.Field(x => x.Id, SortOrder.Desc))
                    .Size(pageSize);
    }
}
