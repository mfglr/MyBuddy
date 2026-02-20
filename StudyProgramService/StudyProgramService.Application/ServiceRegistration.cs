using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramService.Application.UseCases.CreateSP;
using StudyProgramService.Application.UseCases.DeleteSP;
using StudyProgramService.Application.UseCases.MarkSPAsActive;
using StudyProgramService.Application.UseCases.MarkSPAsCompleted;
using StudyProgramService.Application.UseCases.MarkSPAsDraft;
using StudyProgramService.Application.UseCases.MarkSPAsInProgress;
using StudyProgramService.Application.UseCases.UpdateSPDescription;
using StudyProgramService.Application.UseCases.UpdateSPPrice;
using StudyProgramService.Application.UseCases.UpdateSPSchedule;
using StudyProgramService.Application.UseCases.UpdateSPTitle;
using StudyProgramService.Application.UseCases.ValidateSPAApproval;
using StudyProgramService.Application.UseCases.ValidateSPACreation;
using System.Reflection;

namespace StudyProgramService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CreateSPMapper>()
                .AddSingleton<MarkSPAsDraftMapper>()
                .AddSingleton<MarkSPAsActiveMapper>()
                .AddSingleton<MarkSPAsInProgressMapper>()
                .AddSingleton<MarkSPAsCompletedMapper>()
                .AddSingleton<DeleteSPMapper>()
                .AddSingleton<UpdateSPScheduleMapper>()
                .AddSingleton<UpdateSPPriceMapper>()
                .AddSingleton<UpdateSPTitleMapper>()
                .AddSingleton<UpdateSPDescriptionMapper>()
                .AddSingleton<ValidateSPACreationMapper>()
                .AddSingleton<ValidateSPAApprovalMapper>()
                .AddMediatR(x =>
                {
                    x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                });
    }
}
