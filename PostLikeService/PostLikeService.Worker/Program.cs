using PostLikeService.Application;
using PostLikeService.Domain;
using PostLikeService.Infrastructure;
using PostLikeService.Infrastructure.MongoDb;
using PostLikeService.Worker;
using PostLikeService.Worker.MassTransit;

DbConfiguration.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<IAuthService,IdentityService>()
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
