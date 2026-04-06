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
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                        _postFaker.GenerateRandomPost(),
                        _userFaker.GenerateRandomUser()
                    )
                );
        }

        public PostProjection GenerateRandom() => _faker.Generate();

        public List<PostProjection> GetList(int size, string userId)
        {
            List<PostProjection> list = [];
            for (int i = 0; i < size; i++)
            {
                list.Add(new PostProjection(
                    Guid.NewGuid().ToString(),
                    userId,
                    _postFaker.GenerateRandomPost(),
                    _userFaker.GenerateRandomUser(i)
                ));
            }
            return list;
        }
    }
}
