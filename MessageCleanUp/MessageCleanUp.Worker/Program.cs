using MessageCleanUp.Worker;
using MessageService.Application;
using MessageService.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddSingleton<IIdentityService,IdentityService>()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
