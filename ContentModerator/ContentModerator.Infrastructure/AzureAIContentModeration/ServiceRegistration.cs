using Azure;
using Azure.AI.ContentSafety;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContentModerator.Application;

namespace ContentModerator.Infrastructure.AzureAIContentModeration
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddAzureAIContentModerationServices(this IServiceCollection services,IConfiguration configuration) =>
            services
                .AddSingleton(new ContentSafetyClient(
                    new Uri(configuration["AzureAIContentSafety:Endpoint"]!),
                    new AzureKeyCredential(configuration["AzureAIContentSafety:ApiKey"]!)
                ))
                .AddSingleton<ImageResultMapper>()
                .AddSingleton<TextResultMapper>()
                .AddSingleton<IModerator, AzureAIContentModerator>();
    }
}
