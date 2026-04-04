using Bogus;
using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.Fakers
{
    internal class PostProjectionFaker
    {
        private readonly UserFaker _userFaker;
        private readonly PostFaker _postFaker;
        private readonly Faker<PostProjection> _faker;
        
        public PostProjectionFaker(UserFaker userFaker, PostFaker postFaker)
        {
            _userFaker = userFaker;
            _postFaker = postFaker;

            _faker = new Faker<PostProjection>()
                .CustomInstantiator(f => new PostProjection(
                        Guid.NewGuid(),
                        Guid.NewGuid(),
                        _postFaker.GenerateRandomPost(),
                        _userFaker.GenerateRandomUser()
                    )
                );
        }

        public PostProjection GenerateRandom() => _faker.Generate();
    }
}
