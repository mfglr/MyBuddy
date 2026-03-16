using CommentLikeService.Api.Auth;
using CommentLikeService.Api.MassTransit;
using CommentLikeService.Application;
using CommentLikeService.Infrastructure;
using CommentLikeService.Infrastructure.MongoDb;

DbConfiguration.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthenticationAuthorization(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
