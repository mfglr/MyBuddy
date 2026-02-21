using StudyProgramInviteService.Application;

namespace StudyProgramInviteService.Worker.Identity
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services) =>
            services
                .AddScoped<IIdentityService, WorkerIdentityService>();
    }
}
