using Elastic.Clients.Elasticsearch;
using PostQueryService.Application.UseCases;
using PostQueryService.Domain.PostProjectionAggregate;
using Shared;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class PostQueryRepository(ElasticsearchClient client, ElasticSearchOptions options) : IPostQueryRepository
    {
        public async Task<PostProjection?> GetByIdQueryAsync(string id, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync<PostProjection>(
                options.PostIndexName,
                id,
                x => x.Realtime(true),
                cancellationToken: cancellationToken);

            if (!response.IsSuccess())
                throw new ElasticSearchException();

            return response.Source;
        }
        public async Task<IEnumerable<PostProjection>> GetByUserIdAsync(
            string userId,
            int pageSize,
            PaginationKey<string?> cursor,
            CancellationToken cancellationToken
        )
        {
            var response = await client.SearchAsync<PostProjection>(
                (srd) => {
                    srd
                        .Query(x => x.Term(x => x.Field(x => x.UserId).Value(userId)))
                        .Sort(x => x.Field(x => x.Id, cursor.IsDescending ? SortOrder.Desc : SortOrder.Asc));
                    if (cursor.Key != null)
                        srd = srd.SearchAfter(FieldValue.String(cursor.Key));
                    srd.Size(pageSize);
                },
                cancellationToken
            );

            if (!response.IsSuccess())
                throw new ElasticSearchException();

            return response.Documents;
        }

        public async Task<IEnumerable<(PostProjection post, double? score)>> SearchAsync(
            string key,
            double? score,
            string? id,
            int pageSize,
            CancellationToken cancellationToken
        )
        {
            var response = await client.SearchAsync<PostProjection>(
                (srd) => {
                    srd
                        .Query(x => x.Match(x => x.Field(x => x.Content.Value).Query(key).Fuzziness("AUTO")))
                        .Sort(
                            x => x.Score(x => x.Order(SortOrder.Desc)),
                            x => x.Field(x => x.Id, SortOrder.Desc)
                        );
                    if (score != null && id != null)
                        srd = srd.SearchAfter((double)score, id);
                    srd.Size(pageSize).TrackScores(true);
                },
                cancellationToken
            );

            if (!response.IsSuccess())
                throw new ElasticSearchException();

            return response.Hits.Select(x => (x.Source!, x.Score));
        }
    }
}
