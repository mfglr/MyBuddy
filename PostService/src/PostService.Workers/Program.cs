using PostService.Application;
using PostService.Infrastructure;
using PostService.Infrastructure.MongoDB;
using PostService.Workers;
using PostService.Workers.Consumers;

DbConfigration.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddSingleton<IAuthService,NullIdentityService>();

var host = builder.Build();
host.Run();
