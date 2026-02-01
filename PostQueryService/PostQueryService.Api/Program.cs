using PostQueryService.Api.ServiceRegistrations;
using PostQueryService.Application;
using PostQueryService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();