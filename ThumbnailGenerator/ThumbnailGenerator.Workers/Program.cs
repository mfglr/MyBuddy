using ThumbnailGenerator.Application;
using ThumbnailGenerator.Infrastructure;
using ThumbnailGenerator.Infrastructure.FFmpegThumbnailGenerator;
using ThumbnailGenerator.Workers.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var ffmpegInitializer = scope.ServiceProvider.GetRequiredService<FFmpegInitializer>();
    await ffmpegInitializer.InitAsync();
}
host.Run();
