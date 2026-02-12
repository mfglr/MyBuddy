using PostLikeService.Api.ServiceRegistrations;
using PostLikeService.Application;
using PostLikeService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddIdentity(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
