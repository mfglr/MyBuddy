using BlobService.Application.ApplicationServices.CreateContainer;
using BlobService.Application.ApplicationServices.DeleteBlob;
using BlobService.Application.ApplicationServices.GetBlob;
using BlobService.Application.ApplicationServices.UploadBlob;
using BlobService.Application.ApplicationServices.UploadSingleBlob;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace BlobService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBlobApplicationServices(this IServiceCollection services) => 
            services
                .AddMediator(cfg => {
                    cfg.AddConsumer<UploadBlobHandler>();
                    cfg.AddConsumer<UploadSingleBlobHandler>();
                    cfg.AddConsumer<DeleteBlobHandler>();
                    cfg.AddConsumer<GetBlobHandler>();
                    cfg.AddConsumer<CreateContainerHandler>();
                });
    }
}
