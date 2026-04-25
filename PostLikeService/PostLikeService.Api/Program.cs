using PostLikeService.Api.Identity;
using PostLikeService.Api.MassTransit;
using PostLikeService.Application;
using PostLikeService.Domain;
using PostLikeService.Infrastructure;
using PostLikeService.Infrastructure.MongoDb;

DbConfiguration.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddIdentity(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
