//using PostLikeQueryService.Domain.UserAggregate;
//using PostLikeQueryService.Infrastructure.MongoDB;
//using PostLikeQueryService.Intregration.Tests.EqualityComparers;

//namespace PostLikeQueryService.Intregration.Tests
//{
//    public class UserRepositoryIntegrationTests : IClassFixture<MongoFixture>
//    {
//        private readonly MongoFixture _mongoFixture;
//        private readonly UserRepository _userRepository;

//        public UserRepositoryIntegrationTests(MongoFixture mongoFixture)
//        {
//            _mongoFixture = mongoFixture;
//            var database = _mongoFixture.Client.GetDatabase(Guid.NewGuid().ToString());
//            _userRepository = new UserRepository(new MongoContext(database));
//        }

//        [Fact]
//        public async Task UpdateAsync_ShouldNotUpdate_WhenVersionIsOlder()
//        {
//            var id = Guid.NewGuid();
//            var user = new User(id,1,null,"test","test",null);
//            await _userRepository.CreateAync(user, CancellationToken.None);
            
//            var ux = await _userRepository.GetByIdAsync(id, CancellationToken.None);
//            var uy = await _userRepository.GetByIdAsync(id, CancellationToken.None);
//            ux!.TryUpdate(2, null, "furkan", "test", null);
//            uy!.TryUpdate(3, null, "furkan", "mfglr", null);
//            await _userRepository.UpdateAsync(uy, CancellationToken.None);
//            await _userRepository.UpdateAsync(ux, CancellationToken.None);

//            var result = await _userRepository.GetByIdAsync(id, CancellationToken.None);
//            Assert.NotNull(result);
//            Assert.True(UserEqualityComparer.IsEqual(uy, result));
//        }

//        [Theory]
//        [InlineData(100)]
//        public async Task UpdateAsync_ShouldNotUpdateOlderVersion_WhenConccurrencyOccour(int numberOfConccurrentOperations)
//        {
//            var id = Guid.NewGuid();
//            var user = new User(id, 1, null, "test", "test", null);
//            await _userRepository.CreateAync(user, CancellationToken.None);

//            List<Task> tasks = [];
//            for (int i = numberOfConccurrentOperations; i >= 2; i--)
//                tasks.Add(_userRepository.UpdateAsync(new User(id, i, null, $"test{i}", $"test{i}", null), CancellationToken.None));
//            await Task.WhenAll(tasks);

//            var newUser = await _userRepository.GetByIdAsync(id, CancellationToken.None);
//            Assert.NotNull(newUser);
//            Assert.Equal(numberOfConccurrentOperations, newUser.Version);
//            Assert.Equal($"test{numberOfConccurrentOperations}", newUser.Name);
//            Assert.Equal($"test{numberOfConccurrentOperations}", newUser.UserName);
//        }
//    }
//}
