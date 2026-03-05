using MassTransit;
using UserService.Application;
using UserService.Infrastructure;
using UserService.Infrastructure.MongoDB;
using UserService.Worker;
using UserService.Worker.Consumers;

DbConfigration.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<IIdentityService, WorkerIdentityService>()
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
