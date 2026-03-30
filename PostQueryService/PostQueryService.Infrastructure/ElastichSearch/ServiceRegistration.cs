using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Domain;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    public static class ServiceRegistration
    {
        private static ElasticSearchOptions GetOptions(this IConfiguration configuration)
        {
            var section = configuration.GetRequiredSection(nameof(ElasticSearchOptions));
            return new(
                section["Host"]!,
                section["IndexName"]!
            );
        }

        public static IServiceCollection AddElacticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions();
            var clientSettings = new ElasticsearchClientSettings(new Uri(options.Host));
            return services
                .AddSingleton(options)
                .AddSingleton<VersionMapper>()
                .AddSingleton(new ElasticsearchClient(clientSettings))
                .AddScoped<IPostProjectionRepository, PostProjectionRepository>();
        }
    }
}
