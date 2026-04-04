using Elastic.Clients.Elasticsearch;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class UserRepository(ElasticsearchClient client, ElasticSearchOptions options) : IUserRepository
    {
        public async Task<(User? user, long? primaryTerm, long? sequenceNumber)> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync<User>(options.UserIndexName, id,  cancellationToken);

            if (!response.IsSuccess())
                throw new ElasticSearchException();

            if (response.Found)
            {
                return (response.Source, response.PrimaryTerm, response.SeqNo);
            }
            return default;
        }

        public async Task CreateAync(User user, CancellationToken cancellationToken)
        {
            var response = await client.IndexAsync(user, user.Id, x => x.Index(options.UserIndexName), cancellationToken: cancellationToken);
            if(!response.IsSuccess())
                throw new ElasticSearchException();
        }

        public async Task UpdateAsync(User user, long? primaryTerm, long? sequenceNumber, CancellationToken cancellationToken)
        {
            var response = await client.UpdateAsync<User, User>(
                options.UserIndexName,
                user.Id,
                x => x.Doc(user).IfPrimaryTerm(primaryTerm).IfSeqNo(sequenceNumber),
                cancellationToken: cancellationToken
            );

            if (response.ApiCallDetails.HttpStatusCode == 409)
                throw new ConcurrencyException();
            if (!response.IsSuccess())
                throw new ElasticSearchException();
        }
    }
}
