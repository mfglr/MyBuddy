using StudyProgramApplicationService.Application;

namespace StudyProgramApplicationService.Worker.Identity
{
    internal static  class ServiceRegistration
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services) =>
            services
                .AddSingleton<IIdentityService, WorkerIdentityService>();
    }
}
