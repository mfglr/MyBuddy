using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PostQueryService.Domain.PostProjectionAggregate;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class ElasticSearchInitializer
    {
        private static async Task EnsureElasticIsReady(
            ElasticsearchClient client,
            ILogger<ElasticSearchInitializer> logger,
            int maxRetries = 20,
            int delayMs = 1000
        )
        {
            PingResponse response;
            for(int i = 0; i < maxRetries; i++)
            {
                response = await client.PingAsync();
                if (response.IsSuccess())
                    return;

                logger.LogError($"Elasticsearch not ready. Attempt {i + 1}/{maxRetries}. Retrying in {delayMs}ms...");
                await Task.Delay(delayMs);
            }
        }

        public static async Task CreateIndices(ElasticsearchClient client, ElasticSearchOptions options)
        {
            await client.Indices
                .CreateAsync<User>(
                    index => index
                        .Index(options.UserIndexName)
                        .Mappings(
                            mappings => mappings
                                .Properties(
                                    props => props
                                        .Keyword(x => x.Id)
                                        .Date(x => x.DeletedAt)
                                        .IntegerNumber(x => x.Version, x => x.Index(false))
                                        .Keyword(x => x.Name, x => x.Index(false))
                                        .Keyword(x => x.UserName, x => x.Index(false))
                                        .Object(x => x.Media, x => x.Enabled(false))
                                )
                        )
                );

            await client.Indices
                .CreateAsync<PostProjection>(
                    index => index
                        .Index(options.PostIndexName)
                        .Mappings(
                            mappings => mappings
                                .Properties(
                                    props =>
                                        props
                                            .Keyword(x => x.Id)
                                            .Keyword(x => x.UserId)
                                            .Date("createdAt")
                                            .Date("updatedAt")
                                            .Date("softDeletedAt")
                                            .IntegerNumber("version")
                                            .Object(
                                                "content",
                                                obj => obj.Properties(
                                                    props => props
                                                        .Text("value")
                                                        .Object(
                                                            "moderationResult",
                                                            obj => obj.Properties(
                                                                props => props
                                                                    .DoubleNumber("hate")
                                                                    .DoubleNumber("selfHarm")
                                                                    .DoubleNumber("sexual")
                                                                    .DoubleNumber("violence")
                                                            )
                                                        )
                                                )
                                            )
                                            .Object("media", x => x.Enabled(false))
                                            .IntegerNumber("processedVersions", x => x.Index(false))
                                            .Object(
                                                x => x.User,
                                                obj => obj
                                                    .Properties(
                                                        p => p
                                                            .IntegerNumber("version")
                                                            .Keyword("name",x => x.Index(false))
                                                            .Keyword("userName",x => x.Index(false))
                                                            .Object("media",x => x.Enabled(false))
                                                    )
                                            )
                                )
                        )
                );
        }

        public static async Task Init(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetRequiredService<ElasticsearchClient>();
            var options = serviceProvider.GetRequiredService<ElasticSearchOptions>();
            var logger = serviceProvider.GetRequiredService<ILogger<ElasticSearchInitializer>>();

            await EnsureElasticIsReady(client, logger);
            await CreateIndices(client, options);
        }
    }
}
