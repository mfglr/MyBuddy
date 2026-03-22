namespace UserQueryService.CleanUp.Cleanup
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddCleanup(this IServiceCollection services, IConfiguration configuration)
        {
            var cleanupOptions = configuration.GetRequiredSection(nameof(CleanupOptions)).Get<CleanupOptions>();
            return services.AddSingleton(cleanupOptions!);
        }
    }
}
