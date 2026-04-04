using Bogus;
using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.Fakers
{
    internal class PostFaker
    {
        private readonly Faker<Post> _faker;
        private readonly PostContentFaker _postContentFaker;

        public PostFaker(PostContentFaker postContentFaker)
        {
            _postContentFaker = postContentFaker;

            _faker = new Faker<Post>()
                .CustomInstantiator(f => new Post(
                    f.Date.Future(),
                    f.Date.Future(),
                    null,
                    f.Random.Int(min: 1),
                    _postContentFaker.GenerateRandom(),
                    []
                ));
        }

        public Post GenerateRandomPost() => _faker.Generate();
        public Post GenerateNewVersion(Post post) => new(
            post.CreatedAt,
            post.UpdatedAt,
            post.DeletedAt,
            post.Version + 1,
            post.Content,
            post.Media
        );
    }
}
