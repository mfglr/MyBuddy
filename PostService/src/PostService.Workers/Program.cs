using PostService.Application;
using PostService.Infrastructure;
using PostService.Workers;
using PostService.Workers.Consumers;
using PostService.Workers.ServiceRegistrations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddAutoMapper(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddSingleton<IIdentityService,NullIdentityService>();

var host = builder.Build();
host.Run();
