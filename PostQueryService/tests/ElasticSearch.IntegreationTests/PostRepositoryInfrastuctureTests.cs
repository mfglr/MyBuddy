using ElasticSearch.IntegreationTests.EqualityComparers;
using ElasticSearch.IntegreationTests.Fakers;
using ElasticSearch.IntegreationTests.Fixtures;
using PostQueryService.Infrastructure.ElastichSearch;

namespace ElasticSearch.IntegreationTests
{
    public class PostRepositoryInfrastuctureTests : IClassFixture<ElasticFixture>
    {
        private readonly PostProjectionRepository _repository;
        private readonly ElasticSearchOptions _options = new ElasticSearchOptions("", "posts", "", "", "");
        private readonly UserFaker _userFaker = new ();
        private readonly PostContentFaker _postContentFaker = new ();
        private readonly PostFaker _postFaker;
        private readonly PostProjectionFaker _postProjectionFaker;

        public PostRepositoryInfrastuctureTests(ElasticFixture fixture)
        {
            _repository = new(fixture.Client,_options);
            _postFaker = new(_postContentFaker);
            _postProjectionFaker = new(_userFaker, _postFaker);
        }


        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenConcurrencyUpdatedOccour()
        {
            var postProjection = _postProjectionFaker.GenerateRandom();
            var newPost = _postFaker.GenerateNewVersion(postProjection.Post);

            await _repository.CreateAsync(postProjection,CancellationToken.None);
            var (pa, pTa, sNa) = await _repository.GetByIdAsync(postProjection.Id, CancellationToken.None);
            var (pb, pTb, sNb) = await _repository.GetByIdAsync(postProjection.Id, CancellationToken.None);
            pa!.TryUpdatePost(newPost);
            pb!.TryUpdatePost(newPost);

            await _repository.UpdateAsync(postProjection, pTa, sNa, CancellationToken.None);
            var exception = Assert.ThrowsAsync<ConcurrencyException>(
                async () => await _repository.UpdateAsync(pb, pTb, sNb,CancellationToken.None)
            );
            var (pAfterUpdate, _, _) = await _repository.GetByIdAsync(postProjection.Id, CancellationToken.None);
            Assert.NotNull(pAfterUpdate);
            Assert.True(PostProjectionEqualityComparer.IsEqual(pa, pAfterUpdate));
        }

    }
}
