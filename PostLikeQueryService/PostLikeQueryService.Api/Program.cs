using PostLikeQueryService.Api.Auth;
using PostLikeQueryService.Shared;
using PostLikeQueryService.Shared.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddShared(builder.Configuration);

DbInitializer.Init(builder.Services);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
