using PostLikeQueryService.Api.Auth;
using PostLikeQueryService.Application;
using PostLikeQueryService.Infrastructure;
using PostLikeQueryService.Infrastructure.MongoDB;

DbConfigration.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration); ;

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
