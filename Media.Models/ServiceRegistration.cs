using Microsoft.Extensions.DependencyInjection;

namespace Media.Models
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMedia(this IServiceCollection services) =>
            services.AddSingleton<MediaProcessingCompletionEvaluator>();
    }
}
