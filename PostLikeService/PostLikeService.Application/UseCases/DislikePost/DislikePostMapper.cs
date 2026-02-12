using AutoMapper;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.DislikePost
{
    internal class DislikePostMapper : Profile
    {
        public DislikePostMapper()
        {
            CreateMap<PostLike, PostDislikedEvent>()
                .ForCtorParam("UserId", x => x.MapFrom(x => x.Id.UserId))
                .ForCtorParam("PostId", x => x.MapFrom(x => x.Id.PostId));
        }
    }
}
