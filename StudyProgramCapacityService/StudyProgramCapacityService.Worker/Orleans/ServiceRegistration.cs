namespace StudyProgramCapacityService.Worker.Orleans
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddOrleans(this IServiceCollection services) =>
            services
                .AddOrleansClient(x => x.UseLocalhostClustering(30002));
    }
}
