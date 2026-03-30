using Elastic.Clients.Elasticsearch;
using PostQueryService.Domain;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class PostProjectionRepository(ElasticsearchClient client, ElasticSearchOptions options, VersionMapper mapper) : IPostProjectionRepository
    {
        public async Task<PostProjection?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var result = await client.GetAsync<PostProjection>(id, x => x.Index(options.IndexName), cancellationToken);
            return result.Found ? mapper.Map(result) : null;
        }

        public async Task<IReadOnlyCollection<PostProjection>> GetByUserAsync(User user, CancellationToken cancellationToken)
        {
            var result = await client.SearchAsync<PostProjection>(s => s
                .Indices(options.IndexName)
                .Query(q => q.Term(t => t.Field(f => f.User.Id).Value(user.Id))),
                cancellationToken: cancellationToken
            );

            if (!result.IsSuccess())
                throw new Exception();

            return mapper.Map(result);
        }

        public Task CreateAsync(PostProjection postProjection, CancellationToken cancellationToken) =>
            client.IndexAsync(
                postProjection,
                postProjection.Id,
                x => x.Index(options.IndexName),
                cancellationToken: cancellationToken
            );

        public Task DeleteAsync(List<PostProjection> postProjections, CancellationToken cancellationToken) =>
            client.BulkAsync(brd =>
                brd
                    .Index(options.IndexName)
                    .DeleteMany(
                        postProjections,
                        (descriptor, postProjection) => descriptor
                            .Id(postProjection.Id)
                            .IfPrimaryTerm((postProjection.Version as Version)?.PrimaryTerm)
                            .IfSequenceNumber((postProjection.Version as Version)?.SeqNo)
                    ),
                cancellationToken:cancellationToken
            );

        public async Task UpdateAsync(PostProjection postProjection, CancellationToken cancellationToken)
        {
            var response = await client.UpdateAsync<PostProjection, PostProjection>(
                options.IndexName,
                postProjection.Id,
                x => x
                    .Doc(postProjection)
                    .IfPrimaryTerm((postProjection.Version as Version)?.PrimaryTerm)
                    .IfSeqNo((postProjection.Version as Version)?.SeqNo),
                cancellationToken: cancellationToken
            );
            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }


        public async Task UpdateAsync(List<PostProjection> postProjections, CancellationToken cancellationToken)
        {
            var response = await client.BulkAsync(brd =>
                brd
                    .Index(options.IndexName)
                    .UpdateMany(
                        postProjections,
                        (descriptor, postProjection) => descriptor
                            .Id(postProjection.Id)
                            .Doc(postProjection)
                            .IfPrimaryTerm((postProjection.Version as Version)?.PrimaryTerm)
                            .IfSequenceNumber((postProjection.Version as Version)?.SeqNo)
                    ),
                cancellationToken: cancellationToken
            );

            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }
            
    }
}
