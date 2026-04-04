using PostQueryService.Application;
using PostQueryService.Infrastructure;
using PostQueryService.Worker.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    await Initializer.Init(scope.ServiceProvider);
}

host.Run();
