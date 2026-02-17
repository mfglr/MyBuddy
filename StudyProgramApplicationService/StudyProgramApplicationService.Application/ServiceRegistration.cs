using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramApplicationService.Application.UseCases.CreateStudyProgramApplication;
using StudyProgramApplicationService.Application.UseCases.ValidateStudyProgramApplicationStudyProgram;
using System.Reflection;

namespace StudyProgramApplicationService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CreateStudyProgramApplicationMapper>()
                .AddSingleton<ValidateStudyProgramApplicationStudyProgramMapper>()
                .AddSingleton<WorkerIdProvider>()
                .AddMediatR(
                    x =>
                    {
                        x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
