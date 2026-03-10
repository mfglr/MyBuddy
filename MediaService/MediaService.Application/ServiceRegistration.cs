using MediaService.Application.UseCases.AddThumbnail;
using MediaService.Application.UseCases.AddTranscoding;
using MediaService.Application.UseCases.CreateMedia;
using MediaService.Application.UseCases.SetMetadata;
using MediaService.Application.UseCases.SetModerationResult;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediaService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<MediaPreprocessingCompletionEvaluator>()
                .AddSingleton<CreateMedia_MessageGenerator>()
                .AddSingleton<SetMetadata_MessageGenerator>()
                .AddSingleton<SetModerationResult_MessageGenerator>()
                .AddSingleton<CreateMediaMapper>()
                .AddSingleton<SetMetadataMapper>()
                .AddSingleton<SetModerationResultMapper>()
                .AddSingleton<AddThumbnailMapper>()
                .AddSingleton<AddTrascodingMapper>()
                .AddMediatR(x =>
                {
                    x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                })
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
