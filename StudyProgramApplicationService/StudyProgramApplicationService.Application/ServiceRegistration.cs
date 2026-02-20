using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramApplicationService.Application.UseCases.CreateSPA;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsApproved;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsAwaitingCapacityReservation;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsPendingApprovel;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected;
using StudyProgramApplicationService.Application.UseCases.RequestSPAApproval;
using System.Reflection;

namespace StudyProgramApplicationService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CreateSPAMapper>()
                .AddSingleton<MarkSPAAsPendingApprovelMapper>()
                .AddSingleton<RequestSPAApprovalMapper>()
                .AddSingleton<MarkSPAAsRejectedMapper>()
                .AddSingleton<MarkSPAAsApprovedMapper>()
                .AddSingleton<MarkSPAAsAwaitingCapacityReservationMapper>()
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
