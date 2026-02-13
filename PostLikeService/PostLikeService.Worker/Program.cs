using PostLikeService.Application;
using PostLikeService.Infrastructure;
using PostLikeService.Worker;
using PostLikeService.Worker.ServiceRegistrations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<IIdentityService,IdentityService>()
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
