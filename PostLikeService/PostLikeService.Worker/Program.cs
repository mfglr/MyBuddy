using PostLikeService.Application;
using PostLikeService.Infrastructure;
using PostLikeService.Infrastructure.MongoDb;
using PostLikeService.Worker;
using PostLikeService.Worker.MassTransit;

DbConfiguration.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<IIdentityService,IdentityService>()
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
