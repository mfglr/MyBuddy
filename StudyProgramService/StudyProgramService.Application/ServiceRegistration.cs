using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramService.Application.UseCases.CreateStudyProgram;
using StudyProgramService.Application.UseCases.DeleteStudyProgram;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsActive;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsDraft;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsInProgress;
using StudyProgramService.Application.UseCases.UpdateCapacity;
using StudyProgramService.Application.UseCases.UpdateDescription;
using StudyProgramService.Application.UseCases.UpdatePrice;
using StudyProgramService.Application.UseCases.UpdateSchedule;
using StudyProgramService.Application.UseCases.UpdateTitle;
using System.Reflection;

namespace StudyProgramService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CreateStudyProgramMapper>()
                .AddSingleton<MarkStudyProgramAsDraftMapper>()
                .AddSingleton<MarkStudyProgramAsActiveMapper>()
                .AddSingleton<MarkStudyProgramAsInprogressMapper>()
                .AddSingleton<MarkStudyProgramAsCompletedMapper>()
                .AddSingleton<DeleteStudyProgramMapper>()
                .AddSingleton<UpdateScheduleMapper>()
                .AddSingleton<UpdatePriceMapper>()
                .AddSingleton<UpdateTitleMapper>()
                .AddSingleton<UpdateDescriptionMapper>()
                .AddSingleton<UpdateCapacityMapper>()
                .AddMediatR(x =>
                {
                    x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                });
    }
}
