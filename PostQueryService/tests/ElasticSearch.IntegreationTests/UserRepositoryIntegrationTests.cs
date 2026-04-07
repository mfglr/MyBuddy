//using ElasticSearch.IntegreationTests.EqualityComparers;
//using ElasticSearch.IntegreationTests.Fixtures;
//using PostQueryService.Infrastructure.ElastichSearch;

//namespace ElasticSearch.IntegreationTests
//{
//    public class UserRepositoryIntegrationTests : IClassFixture<ElasticFixture>
//    {
//        private readonly ElasticFixture _elasticFixture;
//        private readonly UserRepository _userRepository;
//        private readonly ElasticSearchOptions _options = new("", "", "users", "", "");

//        public UserRepositoryIntegrationTests(ElasticFixture elasticFixture)
//        {
//            _elasticFixture = elasticFixture;
//            _userRepository = new UserRepository(_elasticFixture.Client, _options);
//        }

//        [Fact]
//        public async Task UpdateAsync_ShouldThrowException_WhenConcurrentUpdatesOccur()
//        {
//            var id = Guid.NewGuid();
//            var name = "furkan";
//            var userName = "furkan";
//            var newName = "Muhammed Furkan";
//            var user = new PostQueryService.Domain.UserAggregate.User(id, null, 5, name, userName, null);
            
//            await _userRepository.CreateAync(user,CancellationToken.None);
//            var tuplea = await _userRepository.GetByIdAsync(id, CancellationToken.None);
//            var tupleb = await _userRepository.GetByIdAsync(id, CancellationToken.None);
//            tuplea.user!.TryUpdateUser(null, 6, newName, userName, null);
//            tupleb.user!.TryUpdateUser(null, 6, newName, userName, null);
//            await _userRepository.UpdateAsync(tuplea.user,tuplea.primaryTerm,tuplea.sequenceNumber, CancellationToken.None);
            
//            var exception = Assert.ThrowsAsync<ConcurrencyException>(
//                async () => await _userRepository.UpdateAsync(tupleb.user, tupleb.primaryTerm, tupleb.sequenceNumber, CancellationToken.None)
//            );
//            var tupleAfterUpdate = await _userRepository.GetByIdAsync(id,CancellationToken.None);
//            Assert.NotNull(tupleAfterUpdate.user);
//            Assert.True(UserEqualityComparer.IsEqual(tupleAfterUpdate.user, tuplea.user));
//        }
//    }
//}
