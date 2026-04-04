using PostQueryService.Infrastructure.ElastichSearch;

namespace PostQueryService.Infrastructure
{
    public static class Initializer
    {
        public static Task Init(IServiceProvider serviceProvider) =>
            ElasticSearchInitializer.Init(serviceProvider);
    }
}
