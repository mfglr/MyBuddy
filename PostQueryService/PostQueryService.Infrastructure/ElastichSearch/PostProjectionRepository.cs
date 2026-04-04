using Elastic.Clients.Elasticsearch;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class PostProjectionRepository(ElasticsearchClient client, ElasticSearchOptions options) : IPostProjectionRepository
    {
        public async Task<(PostProjection? postProjection, long? primaryTerm, long? sequenceNumber)> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync<PostProjection>(options.PostIndexName, id, cancellationToken: cancellationToken);

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

        public async Task UpdateAsync(PostProjection postProjection, long? primaryTerm, long? sequenceNumber, CancellationToken cancellationToken)
        {
            var response = await client.UpdateAsync<PostProjection, PostProjection>(
                options.PostIndexName,
                postProjection.Id,
                x => x.Doc(postProjection).IfPrimaryTerm(primaryTerm).IfSeqNo(sequenceNumber),
                cancellationToken: cancellationToken
            );
            if (response.ApiCallDetails.HttpStatusCode == 409)
                throw new ConcurrencyException();
            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }
    }
}
