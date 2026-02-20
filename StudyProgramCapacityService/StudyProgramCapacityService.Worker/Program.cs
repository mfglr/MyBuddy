using StudyProgramCapacityService.Application;
using StudyProgramCapacityService.Infrastructure;
using StudyProgramCapacityService.Worker.Identity;
using StudyProgramCapacityService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddIdentity()
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
