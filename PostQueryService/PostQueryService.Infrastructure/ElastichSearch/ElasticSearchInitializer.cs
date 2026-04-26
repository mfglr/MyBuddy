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
            int delayMs = 1000
        )
        {
            bool isReady = false;
            int i = 1;
            while(!isReady)
            {
                var response = await client.PingAsync();
                if (response.IsSuccess())
                    isReady = true;

                logger.LogError($"Elasticsearch not ready. Attempt {i}. Retrying in {delayMs}ms...");
                await Task.Delay(delayMs);
                i++;
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
                                            .Date("createdAt", x => x.Index(false))
                                            .Date("updatedAt", x => x.Index(false))
                                            .Boolean("isDeleted")
                                            .IntegerNumber("version")
                                            .Object(
                                                "content",
                                                obj => obj.Properties(
                                                    props => props
                                                        .Text("value")
                                                        .Object("moderationResult", obj => obj.Enabled(false))
                                                )
                                            )
                                            .Object("media", x => x.Enabled(false))
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
