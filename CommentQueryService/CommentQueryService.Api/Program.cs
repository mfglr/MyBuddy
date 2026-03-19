using CommentQueryService.Shared;
using CommentQueryService.Shared.PostgreSql;
using PostQueryService.Api.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddShared(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DbInitializer.Init(scope.ServiceProvider);
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
