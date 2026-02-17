using StudyProgramCapacityService.Application;
using StudyProgramCapacityService.Worker.Orleans;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddOrleans()
    .AddApplication(builder.Configuration);

var host = builder.Build();
host.Run();
