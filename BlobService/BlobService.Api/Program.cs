using BlobService.Application;
using BlobService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddBlobApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
