using PostLikeQueryService.Application;
using PostLikeQueryService.Infrastructure;
using PostLikeQueryService.Worker.ServiceRegistrations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostDisliked.Mapper>()
    .AddSingleton<PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostLiked.Mapper>()
    .AddSingleton<PostLikeQueryService.Worker.Consumers.UpgradeUser.Mapper>()
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();

host.Run();
