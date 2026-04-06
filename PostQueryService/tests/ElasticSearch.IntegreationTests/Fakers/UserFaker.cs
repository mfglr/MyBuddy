using Bogus;
using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.Fakers
{
    internal class UserFaker
    {
        private readonly Faker<PostProjectionUser> _faker;

        public UserFaker()
        {
            _faker = new Faker<PostProjectionUser>()
                .CustomInstantiator(f => new PostProjectionUser(
                    f.Random.Int(min:0),
                    f.Name.FirstName(),
                    f.Name.LastName(),
                    null
                ));
        }

        public PostProjectionUser GenerateRandomUser() => _faker.Generate();
        public PostProjectionUser GenerateRandomUser(int version)
        {
            var user = _faker.Generate();
            return new(
                version,
                user.Name,
                user.UserName,
                user.Media
            );
        }
    }
}
