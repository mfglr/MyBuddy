using StudyProgramService.Application;
using StudyProgramService.Infrastructure;
using StudyProgramService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddConsumers(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure();

var host = builder.Build();
host.Run();
