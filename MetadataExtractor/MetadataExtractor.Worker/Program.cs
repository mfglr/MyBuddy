using MetadataExtractor.Application;
using MetadataExtractor.Infrastructure;
using MetadataExtractor.Infrastructure.FFmpegMetadataExtractor;
using MetadataExtractor.Worker.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var ffmpegInitializer = scope.ServiceProvider.GetRequiredService<FFmpegInitializer>();
    await ffmpegInitializer.InitAsync();
}

host.Run();
