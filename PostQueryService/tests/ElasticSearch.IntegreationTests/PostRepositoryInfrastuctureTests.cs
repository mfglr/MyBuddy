using ElasticSearch.IntegreationTests.EqualityComparers;
using ElasticSearch.IntegreationTests.Fakers;
using ElasticSearch.IntegreationTests.Fixtures;
using PostQueryService.Domain.PostProjectionAggregate;
using PostQueryService.Infrastructure.ElastichSearch;

namespace ElasticSearch.IntegreationTests
{
    public class PostRepositoryInfrastuctureTests : IClassFixture<ElasticFixture>
    {
        private readonly PostProjectionRepository _repository;
        private readonly ElasticSearchOptions _options = new ("", "posts", "", "", "");
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

            await _repository.UpdateAsync((postProjection, pTa, sNa), CancellationToken.None);
            var exception = Assert.ThrowsAsync<ConcurrencyException>(
                async () => await _repository.UpdateAsync((pb, pTb, sNb),CancellationToken.None)
            );
            var (pAfterUpdate, _, _) = await _repository.GetByIdAsync(postProjection.Id, CancellationToken.None);
            Assert.NotNull(pAfterUpdate);
            Assert.True(PostProjectionEqualityComparer.IsEqual(pa, pAfterUpdate));
        }

        [Fact]
        public async Task GetPostByUserAsync_ShouldReturnUserPostsWithOlderVersionThanGiven()
        {
            var numberOfPostsPerUser = 50;
            var pageSize = 50;
            var userId = Guid.NewGuid().ToString();
            var userPosts = _postProjectionFaker.GetList(numberOfPostsPerUser, userId);
            List<PostProjection> posts = [
                .. userPosts,
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
            ];
            
            foreach (var post in posts)
                await _repository.CreateAsync(post, CancellationToken.None);
            await _repository.RefreshAsync(); //make posts searchable

            var version = numberOfPostsPerUser;

            
            var response = (await _repository.GetPostByUserAsync(userId, version, null, pageSize, CancellationToken.None))
                    .OrderBy(x => x.postProjection.User.Version)
                    .Select(x => new { x.postProjection.User.Version, x.postProjection.UserId});

            
            var ue = userPosts.GetEnumerator();
            var re = response.GetEnumerator();
            Assert.Equal(response.Count(), userPosts.Count());
            while(ue.MoveNext() && re.MoveNext())
            {
                Assert.Equal(re.Current.UserId, ue.Current.UserId);
                Assert.Equal(re.Current.Version, ue.Current.User.Version);
            }
        }

        [Fact]
        public async Task UpdateManyAsync_ShouldUpdateManyPost_WhenVersionIsNewer()
        {
            var numberOfPostsPerUser = 50;
            var pageSize = 50;
            var userId = Guid.NewGuid().ToString();
            List<PostProjection> posts = [
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, userId),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
                .. _postProjectionFaker.GetList(numberOfPostsPerUser, Guid.NewGuid().ToString()),
            ];

            foreach (var post in posts)
                await _repository.CreateAsync(post, CancellationToken.None);
            await _repository.RefreshAsync(); //make posts searchable

            var version = numberOfPostsPerUser;
            var newUser = new PostProjectionUser(version, "test", "test", null);


            var tuples = (await _repository.GetPostByUserAsync(userId, version, null, pageSize, CancellationToken.None))
                .OrderBy(x => x.postProjection.User.Version);
            foreach (var  (postProjection, primaryTerm, sequenceNumber) in tuples)
                postProjection.TryUpdateUser(newUser);
            await _repository.UpdateManyAsync(tuples, CancellationToken.None);
            await _repository.RefreshAsync(); //make posts updates searchable


            var newTuples = (await _repository.GetPostByUserAsync(userId, version + 1, null, pageSize, CancellationToken.None))
                .OrderBy(x => x.postProjection.User.Version);

            var nte = newTuples.GetEnumerator();
            var te = tuples.GetEnumerator();

            while(nte.MoveNext() && te.MoveNext())
                Assert.True(PostProjectionEqualityComparer.IsEqual(nte.Current.postProjection, te.Current.postProjection));
        }

        [Fact]
        public async Task UpdateManyAsync_ShouldThrowExceptin_ConcurrencyUpdatedOccour()
        {
            var numberOfPostsPerUser = 5;
            var userId = Guid.NewGuid().ToString();
            var singlePost = _postProjectionFaker.GetList(1, userId).First();
            List<PostProjection> posts = [
                singlePost, .. _postProjectionFaker.GetList(numberOfPostsPerUser - 1, userId),
            ];

            foreach (var post in posts)
                await _repository.CreateAsync(post, CancellationToken.None);
            await _repository.RefreshAsync(); //make posts searchable

            var version = numberOfPostsPerUser;
            var pageSize = numberOfPostsPerUser;
            var newUser = new PostProjectionUser(version, "test", "test", null);


            var tuples = await _repository.GetPostByUserAsync(userId, version, null, pageSize, CancellationToken.None);

            var tuple = await _repository.GetByIdAsync(singlePost.Id, CancellationToken.None);
            tuple.postProjection!.TryUpdateUser(newUser);
            await _repository.UpdateAsync(tuple!, CancellationToken.None);

            foreach (var (postProjection, primaryTerm, sequenceNumber) in tuples)
                postProjection.TryUpdateUser(newUser);

            
            await Assert.ThrowsAsync<ConcurrencyException>(async () => await _repository.UpdateManyAsync(tuples, CancellationToken.None));
        }
    }
}
