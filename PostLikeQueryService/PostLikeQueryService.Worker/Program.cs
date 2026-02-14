using PostLikeQueryService.Application;
using PostLikeQueryService.Infrastructure;
using PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserCreated;
using PostLikeQueryService.Worker.ServiceRegistrations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostDisliked.Mapper>()
    .AddSingleton<PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostLiked.Mapper>()
    .AddSingleton<Mapper>()
    .AddSingleton<PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserNameUpdated.Mapper>()
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();

host.Run();
