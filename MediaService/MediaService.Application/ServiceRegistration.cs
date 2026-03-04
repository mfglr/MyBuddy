using MediaService.Application.UseCases.CreateMedia;
using MediaService.Application.UseCases.SetMetadata;
using MediaService.Application.UseCases.SetModerationResult;
using MediaService.Application.UseCases.SetThumbnails;
using MediaService.Application.UseCases.SetTranscodedBlobName;
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
                .AddSingleton<CreateMediaMapper>()
                .AddSingleton<SetMetadataMapper>()
                .AddSingleton<SetModerationResultMapper>()
                .AddSingleton<SetThumbnailsMapper>()
                .AddSingleton<SetTranscodedBlobNameMapper>()
                .AddMediatR(x =>
                {
                    x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                })
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
