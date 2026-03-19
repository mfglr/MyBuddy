using AuthServer.Application.UseCases.CreateAccount;
using AuthServer.Application.UseCases.CreateMedia;
using AuthServer.Application.UseCases.DeleteAccount;
using AuthServer.Application.UseCases.SetMedia;
using AuthServer.Application.UseCases.UpdateEmail;
using AuthServer.Application.UseCases.UpdateGender;
using AuthServer.Application.UseCases.UpdateName;
using AuthServer.Application.UseCases.UpdateUserName;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthServer.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<MediaInstructionGenerator>()
                .AddSingleton<MediaTypeExtractor>()
                .AddSingleton<CreateAccountMapper>()
                .AddSingleton<UpdateEmailMapper>()
                .AddSingleton<UpdateUserNameMapper>()
                .AddSingleton<UpdateNameMapper>()
                .AddSingleton<UpdateGenderMapper>()
                .AddSingleton<CreateMediaMapper>()
                .AddSingleton<SetMediaMapper>()
                .AddSingleton<DeleteAccountMapper>()
                .AddMediatR(
                    cfg => {
                        cfg.LicenseKey = configuration.GetSection("LuckPenny:LicenseKey").Value;
                        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                    }
                )
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
