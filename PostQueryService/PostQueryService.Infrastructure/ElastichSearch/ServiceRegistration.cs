using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Application.UseCases;
using PostQueryService.Domain.PostProjectionAggregate;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    public static class ServiceRegistration
    {
        private static ElasticSearchOptions GetOptions(this IConfiguration configuration)
        {
            var section = configuration.GetRequiredSection(nameof(ElasticSearchOptions));
            return new(
                section["Host"]!,
                section["PostIndexName"]!,
                section["UserIndexName"]!,
                section["UserName"]!,
                section["Password"]!
            );
        }

        public static IServiceCollection AddElacticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions();
            var clientSettings = new ElasticsearchClientSettings(new Uri(options.Host))
                .Authentication(new BasicAuthentication(options.UserName, options.Password))
                .ServerCertificateValidationCallback((o, cert, chain, errors) => true);

            return services
                .AddSingleton(options)
                .AddSingleton(new ElasticsearchClient(clientSettings))
                .AddScoped<IPostProjectionRepository, PostProjectionRepository>()
                .AddScoped<IPostQueryRepository,PostQueryRepository>()
                .AddScoped<IUserRepository,UserRepository>();
        }
    }
}
