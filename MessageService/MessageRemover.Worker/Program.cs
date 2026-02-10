using MessageRemover.Worker;
using MessageService.Aplication.UseCases.DeleteMessageDeliveries;
using MessageService.Aplication.UseCases.DeleteMessageReadReceipts;
using MessageService.Aplication.UseCases.DeleteMessages;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .Add_DeletMessages_UseCase(builder.Configuration)
    .Add_DeleteMessageDeliveries_UseCase(builder.Configuration)
    .Add_DeleteMessageReadReceipts_UseCase(builder.Configuration);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
