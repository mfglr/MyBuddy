using AutoMapper;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.LikePost
{
    internal class LikePostMapper : Profile
    {
        public LikePostMapper()
        {
            CreateMap<PostLike, PostLikedEvent>()
                .ForCtorParam("UserId", x => x.MapFrom(x => x.Id.UserId))
                .ForCtorParam("PostId", x => x.MapFrom(x => x.Id.PostId));
        }
    }
}
