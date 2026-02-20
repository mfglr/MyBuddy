using StudyProgramApplicationService.Application;
using StudyProgramApplicationService.Domain;
using StudyProgramApplicationService.Infrastructure;
using StudyProgramApplicationService.Worker.Identity;
using StudyProgramApplicationService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddIdentity()
    .AddConsumers(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
