using VideoTranscoder.Application;
using VideoTranscoder.Infrastructure;
using VideoTranscoder.Infrastructure.FFmpegVideoTranscoder;
using VideoTranscoder.Worker.Consumers;

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
