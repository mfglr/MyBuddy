using StudyProgramService.Application;
using StudyProgramService.Infrastructure;
using StudyProgramService.Worker.Identity;
using StudyProgramService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddIdentity()
    .AddConsumers(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
