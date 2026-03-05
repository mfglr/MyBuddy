using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.UseCases.CreateMedia;
using UserService.Application.UseCases.CreateUser;
using UserService.Application.UseCases.DeleteMedia;
using UserService.Application.UseCases.SetMedia;
using UserService.Application.UseCases.UpdateGender;
using UserService.Application.UseCases.UpdateName;
using UserService.Application.UseCases.UpdateUserName;

namespace UserService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<MediaTypeExtractor>()
                .AddSingleton<MediaInstructionGenerator>()
                .AddSingleton<CreateMediaMapper>()
                .AddSingleton<DeleteMediaMapper>()
                .AddSingleton<CreateUserMapper>()
                .AddSingleton<SetMediaMapper>()
                .AddSingleton<UpdateGenderMapper>()
                .AddSingleton<UpdateNameMapper>()
                .AddSingleton<UpdateUserNameMapper>()
                .AddMediatR(
                    cfg => {
                        cfg.LicenseKey = configuration.GetSection("LuckPenny:LicenseKey").Value;
                        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                    }
                )
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
