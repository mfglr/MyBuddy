using Elastic.Clients.Elasticsearch;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class PostProjectionRepository(ElasticsearchClient client, ElasticSearchOptions options) : IPostProjectionRepository
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


        public async Task<(PostProjection? postProjection, long? primaryTerm, long? sequenceNumber)> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync<PostProjection>(
                options.PostIndexName,
                id,
                x => x.Realtime(true),
                cancellationToken: cancellationToken);

            if (!response.IsSuccess())
                throw new ElasticSearchException();

            if (!response.Found)
                return default;

            return (response.Source, response.PrimaryTerm, response.SeqNo);
        }

        public async Task CreateAsync(PostProjection postProjection, CancellationToken cancellationToken)
        {
            var response = await client.IndexAsync(
                postProjection,
                postProjection.Id,
                x => x.Index(options.PostIndexName),
                cancellationToken: cancellationToken
            );

            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }

        public async Task UpdateAsync((PostProjection postProjection, long? primaryTerm, long? sequenceNumber) tuple, CancellationToken cancellationToken)
        {
            var response = await client.UpdateAsync<PostProjection, PostProjection>(
                options.PostIndexName,
                tuple.postProjection.Id,
                x => x
                    .Doc(tuple.postProjection)
                    .IfPrimaryTerm(tuple.primaryTerm)
                    .IfSeqNo(tuple.sequenceNumber),
                cancellationToken: cancellationToken
            );
            if (response.ApiCallDetails.HttpStatusCode == 409)
                throw new ConcurrencyException();
            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }

        public async Task<List<(PostProjection postProjection, long? primaryTerm, long? sequenceNumber)>> GetPostByUserAsync(
            string userId,
            int version,
            string? cursor,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var response = await client.SearchAsync<PostProjection>(
                options.PostIndexName,
                x => x
                    .SeqNoPrimaryTerm(true)
                    .Query(
                        x => x
                            .Bool(
                                b => b.Filter(
                                    f => f.Term(x => x.Field(f => f.UserId).Value(userId.ToString())),
                                    f => f.Range(x => x.Number(x => x.Field(f => f.User.Version).Lt(version)))
                                )
                            )
                    )
                    .ToPage(cursor,pageSize),
                cancellationToken: cancellationToken
            );

            if (!response.IsSuccess())
                throw new ElasticSearchException();
            
            var de = response.Documents.GetEnumerator();
            var he = response.Hits.GetEnumerator();
            List<(PostProjection postProjection, long? primaryTerm, long? sequenceNumber)> r = [];
            while (de.MoveNext() && he.MoveNext())
                r.Add((de.Current, he.Current.PrimaryTerm, he.Current.SeqNo));
            return r;
        }

        public async Task UpdateManyAsync(IEnumerable<(PostProjection postProjection, long? primaryTerm, long? sequenceNumber)> tuples, CancellationToken cancellationToken)
        {
            if (!tuples.Any()) return;

            var response = await client.BulkAsync(
                bulk => {
                    foreach (var (postProjection, primaryTerm, sequenceNumber) in tuples)
                        bulk
                            .Index(
                                postProjection,
                                options.PostIndexName,
                                u => u
                                    .Id(postProjection.Id)
                                    .IfPrimaryTerm(primaryTerm)
                                    .IfSequenceNumber(sequenceNumber)
                            );
                },
                cancellationToken
            );

            foreach (var item in response.Items)
                if (item.Status == 409)
                    throw new ConcurrencyException();
            
            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }

        public Task DeleteAsync(PostProjection postProjection, CancellationToken cancellationToken) =>
            client.DeleteAsync(options.PostIndexName, postProjection.Id,cancellationToken: cancellationToken);

        internal Task RefreshAsync() => client.Indices.RefreshAsync(options.PostIndexName);

    }
}
