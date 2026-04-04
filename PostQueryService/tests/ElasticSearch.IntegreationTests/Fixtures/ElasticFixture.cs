using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Testcontainers.Elasticsearch;

namespace ElasticSearch.IntegreationTests.Fixtures
{
    public class ElasticFixture : IAsyncLifetime
    {
        private ElasticsearchContainer _container = default!;
        public ElasticsearchClient Client { get; private set; } = default!;

        public async Task InitializeAsync()
        {
            _container = new ElasticsearchBuilder("docker.elastic.co/elasticsearch/elasticsearch:9.3.2").Build();
            await _container.StartAsync();

            var settings = new ElasticsearchClientSettings(new Uri(_container.GetConnectionString()))
                .ServerCertificateValidationCallback(CertificateValidations.AllowAll);

            Client = new ElasticsearchClient(settings);
        }

        public async Task DisposeAsync()
        {
            await _container.StopAsync();
            await _container.DisposeAsync();
        }
    }
}
