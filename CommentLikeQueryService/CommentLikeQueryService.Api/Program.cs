using CommentLikeQueryService.Api.Auth;
using CommentLikeQueryService.Application;
using CommentLikeQueryService.Infrastructure;
using CommentLikeQueryService.Infrastructure.MongoDB;

DbConfiguration.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthenticationAuthorization(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
