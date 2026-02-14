using PostLikeQueryService.Application;
using PostLikeQueryService.Infrastructure;
using PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostDisliked;
using PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostLiked;
using PostLikeQueryService.Worker.Consumers.UpgradeUser_OnNameUpdated;
using PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserCreated;
using PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserMediaPreprocessingCompleted;
using PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserNameUpdated;
using PostLikeQueryService.Worker.ServiceRegistrations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<UpgradePostLike_OnPostDisliked_Mapper>()
    .AddSingleton<UpgradePostLike_OnPostLiked_Mapper>()

    .AddSingleton<UpgradeUser_OnUserCreated_Mapper >()
    .AddSingleton<UpgradeUser_OnUserNameUpdated_Mapper>()
    .AddSingleton<UpgradeUser_OnNameUpdated_Mapper>()
    .AddSingleton<UpgradeUser_OnUserMediaPreprocessingCompleted_Mapper>()

    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();

host.Run();
