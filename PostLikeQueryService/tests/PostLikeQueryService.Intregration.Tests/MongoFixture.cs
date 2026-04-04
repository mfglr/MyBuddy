using MongoDB.Driver;
using PostLikeQueryService.Infrastructure.MongoDB;
using Testcontainers.MongoDb;

namespace PostLikeQueryService.Intregration.Tests
{
    public class MongoFixture : IAsyncLifetime
    {
        private MongoDbContainer _container = default!;
        public IMongoClient Client { get; private set; } = default!;

        public async Task InitializeAsync()
        {
            DbConfigration.Configure();
            _container = new MongoDbBuilder("mongo")
                .WithReplicaSet("rs0")
                .Build();
            await _container.StartAsync();
            Client = new MongoClient(_container.GetConnectionString());
        }

        public Task DisposeAsync() => _container.DisposeAsync().AsTask();
    }
}
