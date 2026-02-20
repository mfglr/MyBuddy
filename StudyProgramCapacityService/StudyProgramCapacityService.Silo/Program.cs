using Orleans.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseOrleans(
        siloBuilder =>
        {
            siloBuilder.UseLocalhostClustering(11113,30002);
            siloBuilder
                .AddAdoNetGrainStorage("StudyProgramCapacity", options =>
                {
                    options.ConnectionString = builder.Configuration.GetConnectionString("PostgreSql");
                    options.Invariant = "Npgsql";
                })
                .Configure<ExceptionSerializationOptions>(o => o.SupportedExceptionTypeFilter = _ => true);
        }
    );

var app = builder.Build();
app.Run();

