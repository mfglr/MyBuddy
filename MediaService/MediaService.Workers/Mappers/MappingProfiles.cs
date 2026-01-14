using AutoMapper;
using MediaService.Application.UseCases;
using MediaService.Application.UseCases.CreateMedia;
using MediaService.Domain;
using Shared.Events.MediaService;
using Shared.Events.PostService;

namespace MediaService.Workers.Mappers
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Media, MediaResponse>();
            CreateMap<MediaResponse, MediaPreprocessingCompletedEvent>();

            CreateMap<Media, CreateMediaRequest_Media>();
            CreateMap<PostMediaCreatedEvent, CreateMediaRequest>();
        }
    }
}
