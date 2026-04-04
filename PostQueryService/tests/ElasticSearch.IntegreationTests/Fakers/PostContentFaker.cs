using Bogus;
using Media.Models;
using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.Fakers
{
    internal class PostContentFaker
    {
        private readonly Faker<PostContent> _faker;

        public PostContentFaker()
        {
            _faker = new Faker<PostContent>()
                .CustomInstantiator(
                    f => new PostContent(
                        f.Lorem.Sentence(),
                        new ModerationResult(0,0,0,0)
                    )
                );
        }

        public PostContent GenerateRandom() => _faker.Generate();
    }
}
