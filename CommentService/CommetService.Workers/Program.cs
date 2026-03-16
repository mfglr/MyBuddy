using CommentService.Application;
using CommentService.Domain;
using CommentService.Infrastructure;
using CommentService.Infrastructure.MongoDb;
using CommetService.Workers;
using CommetService.Workers.MassTransit;

DbConfigurator.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddScoped<IAuthService, WorkerIdentiyService>()
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
