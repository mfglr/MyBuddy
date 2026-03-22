using CommentQueryService.Api.Auth;
using CommentQueryService.Infrastructure;
using CommentQueryService.Infrastructure.MongoDB;
using CommentQueryService.Application;

DbConfigurator.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    IndexCreator.Create(scope.ServiceProvider);
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
