using AutoMapper;
using PostService.Application.UseCases.SetPostMedia;
using Shared.Events.MediaService;
using Shared.Events.PostService;

namespace PostService.Workers.Consumers.SetPostMedia
{
    internal class SetPostMediaMapper : Profile
    {
        public SetPostMediaMapper()
        {
            CreateMap<MediaPreprocessingCompletedEvent, SetPostMediaRequest>();
            CreateMap<SetPostMediaResponse_Content, PostMediaSetEvent_Content>();
            CreateMap<SetPostMediaResponse, PostMediaSetEvent>();
        }
    }
}
