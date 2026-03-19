using AuthServer.Application.UseCases.CreateAccount;
using AuthServer.Application.UseCases.DeleteAccount;
using AuthServer.Application.UseCases.UpdateName;
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
                .AddSingleton<CreateAccountMapper>()
                .AddSingleton<DeleteAccountMapper>()
                .AddSingleton<UpdateNameMapper>()
                .AddMediatR(
                    cfg => {
                        cfg.LicenseKey = configuration.GetSection("LuckPenny:LicenseKey").Value;
                        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                    }
                )
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
