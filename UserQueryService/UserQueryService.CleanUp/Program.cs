using UserQueryService.CleanUp;
using UserQueryService.CleanUp.Cleanup;
using UserQueryService.Shared;
using UserQueryService.Shared.MongoDB;

DbConfigration.Configure();

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services
    .AddCleanup(builder.Configuration)
    .AddShared(builder.Configuration);

var host = builder.Build();
host.Run();
