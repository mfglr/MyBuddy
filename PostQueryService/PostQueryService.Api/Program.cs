using PostQueryService.Api.Auth;
using PostQueryService.Shared;
using PostQueryService.Shared.PostgreSql;

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